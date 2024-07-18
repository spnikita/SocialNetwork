﻿namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public static void Show()
        {
            Console.WriteLine("Войти в профиль (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.AuthenticationView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.RegistrationView.Show();
                        break;
                    }
            }
        }
    }
}
