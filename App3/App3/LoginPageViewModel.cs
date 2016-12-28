using System;

namespace App3
{
    class LoginPageViewModel
    {
        internal Users AddUser(string _user, string _pass)
        {
            try
            {
                var user = App.DB.FindUserByName(_user);
                if (user != null)
                {
                    App.Current.MainPage.DisplayAlert("Usuario Registrado", "Este nombre de usuario ya se encuentra registrado", "ok");
                    return user;
                }
                var item = new Users
                {
                    User = _user,
                    Pass = _pass,
                    FechaAlta = DateTime.Now
                };
                App.Current.MainPage.DisplayAlert("Usuario Registrado", "Se Registro correctamente el usuario " + _user, "ok");
                return App.DB.SaveItem(item);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error de Registro", ex.Message, "ok");
                return null;
            }

        }

        internal Users CheckUser(string _user, string _pass)
        {
            var user = App.DB.FindUserByName(_user);
            if (user == null) {
                App.Current.MainPage.DisplayAlert("Usuario no Registrado", "No existe el usuario " + _user, "ok");
                return null;
            }
            if (user.Pass != _pass)
            {
                App.Current.MainPage.DisplayAlert("Password erroneo", "Verifique su usuario" + _user, "ok");
                return null;
            }
            App.Current.MainPage.DisplayAlert("Autenticado", "Bienvenido " + user.User, "ok");
            return user;
            //App.Current.MainPage = new Page();
        }
    }
}