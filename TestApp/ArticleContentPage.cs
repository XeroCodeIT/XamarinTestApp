using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestApp
{
    public class ArticleContentPage : ContentPage
    {
        private WebView _webView;

        public ArticleContentPage()
        {
            Content = _webView = new WebView();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Title = "TestApp: embedded website";
            _webView.Source = new UrlWebViewSource {Url = Article.ArticleUrl};
        }

        public Article Article { get; set; } 
    }
}
