using App3.Models;
using App3.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App3.Views
{
    public class LoginPage : ContentPage
    {
        private LoginPageViewModel vm;
        private int updateID;

        public List<Users> Users { get; set; }
        public Users UserSession { get; set; }
        public Entry UserName { get; set; }
        public Entry UserPass { get; set; }
        public LoginPage()
        {

            vm = new LoginPageViewModel();
            BindingContext = vm;

            Users = App.DB.GetAll();

            var label1 = new Label
            {
                Text = "User:",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            UserName = new Entry
            {
                WidthRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                AutomationId = "UserName"
            };

            var label2 = new Label
            {
                Text = "Password:",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            UserPass = new Entry
            {
                WidthRequest = 150,
                IsPassword = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                AutomationId = "UserPass"
            };

            var button1 = new Button
            {
                Text = "Login",
                BackgroundColor = Color.White,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Center
            };
            button1.Clicked += OnLogin;

            var button2 = new Button
            {
                Text = "Register",
                WidthRequest = 150,
                BackgroundColor = Color.Blue,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center
            };

            button2.Clicked += OnRegister;

            var buttonLayout = new StackLayout
            {
                Spacing = 10,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                        button1,
                        button2
                    }
            };

            Content = new StackLayout
            {
                Padding = 60,
                Spacing = 10,
                Children = {
                        label1,
                        UserName,
                        label2,
                        UserPass,
                        buttonLayout
                    },

            };

        }


        private void OnLogin(object sender, EventArgs e)
        {
            vm.CheckUser(UserName.Text, UserPass.Text);
            //Navigation.PushAsync(new MainMenu(UserName.Text));
            Clear();
        }

        private void OnRegister(object sender, EventArgs e)
        {
            UserSession = vm.AddUser(UserName.Text, UserPass.Text);
            Clear();
        }

        private void Clear()
        {
            UserName.Text = UserPass.Text = String.Empty;
        }
    }
}