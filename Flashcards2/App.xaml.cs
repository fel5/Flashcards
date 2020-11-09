using Flashcards2.DataLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Flashcards2.Views;
using Flashcards2.ViewModels;
using Autofac;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Autofac.Core;
using Flashcards2.Commands;
using System.Runtime.CompilerServices;
using Autofac.Builder;
using Flashcards2.BusinessLogic;
using Autofac.Features.OwnedInstances;

namespace Flashcards2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string _appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"\\Flashcards";
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            System.IO.Directory.CreateDirectory(_appData);
            var container = ContainerConfig();
            using (var scope = container.BeginLifetimeScope())
            {
                var dbcontext = scope.Resolve<FlashcardsDbContext>();
                dbcontext.Database.Migrate();
            }
            Window window = container.Resolve<MainWindow>();
            window.Show();
        }

        public IContainer ContainerConfig()
        {
            var builder = new ContainerBuilder();

            var options = new DbContextOptionsBuilder<FlashcardsDbContext>();
            options.UseSqlite("Data Source="+_appData+"\\Flashcards.db");
            

            builder.RegisterType<FlashcardsDbContext>()
                   .WithParameter("options", options.Options)
                   .AsSelf()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Action"))
                   .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(RelayCommand<>))
                   .AsSelf();

            builder.RegisterType<RelayCommand>()
                   .AsSelf();

            builder.RegisterGeneric(typeof(RunnerWriteDb<,>))
                   .AsSelf()
                   .InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("ViewModel") && !t.Name.Equals(nameof(MainWindowViewModel)))
                   .AsSelf()
                   .InstancePerLifetimeScope();

            builder.RegisterType<MainWindowViewModel>()
                   .AsSelf()
                   .SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("View"))
                   .AsSelf()
                   .InstancePerDependency();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Window"))
                   .PropertiesAutowired()
                   .AsSelf();

            return builder.Build();
        }
    } 
}
