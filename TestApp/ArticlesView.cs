﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestApp
{
    public class ArticlesView : ContentPage
    {
        public ArticlesView()
        {
            Label header = new Label
            {
                Text = "ListView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Title = "TestApp: hyperlink list";
            var listView = new ListView();

            var textCell = new DataTemplate(typeof(TextCell));
            textCell.SetBinding(TextCell.TextProperty, "Title");
            textCell.SetBinding(TextCell.DetailProperty, "Author");
            listView.ItemTemplate = textCell;
            listView.ItemsSource = DataService.GetArticles();
            listView.ItemSelected += ListView_ItemSelected;
            Content = listView;

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var page = new ArticleContentPage {Article = e.SelectedItem as Article};
            await Navigation.PushAsync(page, true);

            var listView = sender as ListView;
            listView.SelectedItem = null;
        }
    }
}
