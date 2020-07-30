﻿using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.Infastructure.Mapping;
using IPRotarenko.Models;
using IPRotarenko.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Services.InCookies
{
    public class CookiesCartService : ICartService
    {
        private readonly string _CartName;
        private readonly IProductData _ProductData;
        private readonly IHttpContextAccessor _HttpContextAccessor;

        private Cart Cart
        {
            get
            {
                var context = _HttpContextAccessor.HttpContext;
                var cookies = context.Response.Cookies;
                var cart_cookie = context.Request.Cookies[_CartName];
                if (cart_cookie is null)
                {
                    var cart = new Cart();
                    cookies.Append(_CartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }

                ReplaceCookie(cookies, cart_cookie);
                return JsonConvert.DeserializeObject<Cart>(cart_cookie);
            }
            set => ReplaceCookie(_HttpContextAccessor.HttpContext.Response.Cookies, JsonConvert.SerializeObject(value));
        }

        private void ReplaceCookie(IResponseCookies cookies, string cookie)
        {
            cookies.Delete(_CartName);
            cookies.Append(_CartName, cookie, new CookieOptions { Expires = DateTime.Now.AddDays(15) });
        }

        public CookiesCartService(IProductData ProductData, IHttpContextAccessor HttpContextAccessor)
        {
            _ProductData = ProductData;
            _HttpContextAccessor = HttpContextAccessor;
            _CartName = "IPRotarenko.Cart";
        }

        public void AddToCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item is null)
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            else
                item.Quantity++;

            Cart = cart;
        }

        public void DecrementFromCart(int id, decimal count)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item is null) return;
            if (item.Quantity <= count)
                cart.Items.Remove(item);
            if (item.Quantity > count)
                item.Quantity = item.Quantity - count;
            //if (item.Quantity == 0)
            //    cart.Items.Remove(item);
            Cart = cart;
        }
        public void AddFromCart(int id, decimal count)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item is null) return;
            item.Quantity = item.Quantity + count;
            Cart = cart;
        }

        public void RemoveFromCart(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);

            if (item is null) return;
            cart.Items.Remove(item);

            Cart = cart;
        }

        public void RemoveAll()
        {
            var cart = Cart;
            cart.Items.Clear();
            Cart = cart;
        }

        public CartViewModel TransformFromCart()
        {
            var products = _ProductData.GetProducts(new ProductFilter
            {
                Ids = Cart.Items.Select(item => item.ProductId).ToList()
            });

            var product_view_models = products.ToView();

            return new CartViewModel
            {
                Items = Cart.Items.ToDictionary(
                    item => product_view_models.First(p => p.Id == item.ProductId),
                    item => item.Quantity
                    )
            };
        }
    }
}
