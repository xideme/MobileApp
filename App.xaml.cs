﻿namespace MobileApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new AppShell());
	}
}
