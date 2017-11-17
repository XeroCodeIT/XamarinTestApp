using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestApp
{
    class MenuView : ContentPage
    {
        class NewsArticle
        {
            public NewsArticle(string name, DateTime birthday, Color color)
            {
                this.Name = name;
                this.Birthday = birthday;
                this.Color = color;
            }

            public string Name { private set; get; }
            public DateTime Birthday { private set; get; }
            public Color Color { private set; get; }
        };

        public MenuView()
        {
            Title = "TestApp: Native controls";
            Label header = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var btn = new Button
            {
                Text = "Open hyperlink list",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            var slider = new Slider
            {
            };

            var switchCell = new Switch
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var clock = new TimePicker()
            {
                Time = new TimeSpan(17, 0, 0)
            };

            btn.Clicked += btn_Clicked;

            // Define some data.
            List<NewsArticle> NewsArticles = new List<NewsArticle>
            {
                new NewsArticle("News #1", new DateTime(2017, 11, 15), Color.Yellow),
                new NewsArticle("News #2", new DateTime(2017, 10, 20), Color.Silver),
                new NewsArticle("News #3", new DateTime(2017, 9, 10), Color.Purple),
                new NewsArticle("News #4", new DateTime(2017, 8, 5), Color.Red),
                new NewsArticle("News #5", new DateTime(2017, 7, 15), Color.Teal),
                new NewsArticle("News #6", new DateTime(2017, 6, 20), Color.Green),
                new NewsArticle("News #7", new DateTime(2017, 5, 10), Color.Gray),
                new NewsArticle("News #8", new DateTime(2017, 4, 5), Color.Blue)
            };

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = NewsArticles,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    Label birthdayLabel = new Label();
                    birthdayLabel.SetBinding(Label.TextProperty,
                        new Binding("Birthday", BindingMode.OneWay,
                            null, null, "Born {0:d}"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "Color");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                    }
                                }
                        }
                    };
                })
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    listView,
                    slider,
                    switchCell,
                    datePicker,
                    clock,
                    btn,
                }
            };
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArticlesView());
        }
    }
}