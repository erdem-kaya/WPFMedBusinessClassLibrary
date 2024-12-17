using Business.Interfaces;
using Business.Services;
using ConsoleApp.Dialogs;
using ConsoleApp.UI;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<IUserService, UserService>();
services.AddSingleton<IFileService, FileService>();
services.AddTransient<UserService, UserService>();


services.AddTransient<UICreateUser>();
services.AddTransient<UIListUser>();
services.AddTransient<UIUpdateUser>();
services.AddTransient<UIDeleteUser>();


services.AddTransient<MenuDialog>();

var serviceProvider = services.BuildServiceProvider();
var menuDialog = serviceProvider.GetRequiredService<MenuDialog>();
menuDialog.MenuOptions();