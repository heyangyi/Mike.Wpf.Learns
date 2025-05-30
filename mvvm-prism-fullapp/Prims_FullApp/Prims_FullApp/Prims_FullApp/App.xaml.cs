﻿using Prism.Ioc;
using Prims_FullApp.Views;
using System.Windows;
using Prism.Modularity;
using Prims_FullApp.Modules.ModuleName;
using Prims_FullApp.Services.Interfaces;
using Prims_FullApp.Services;

namespace Prims_FullApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IMessageService, MessageService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleNameModule>();
        }
    }
}
