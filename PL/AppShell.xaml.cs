﻿namespace PL;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(TabPage), typeof(TabPage));
	}
}
