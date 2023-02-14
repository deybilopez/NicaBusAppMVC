﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NicaBusMVC.Application.Command;
using NicaBusMVC.Application.CommandsHandler;
using NicaBusMVC.Application.QueryHandler;
using NicaBusMVC;
using NicaBusMVC.Configuration;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NicaBusMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NicaBusMVCContext") ?? throw new InvalidOperationException("Connection string 'NicaBusMVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnidOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddScoped<ICommandHandler<UserDTO>, AddPermissionCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveByIdCommand>, RemovePermissionCommandHandler>();
builder.Services.AddScoped<IQueryHandler<User, QueryByIdCommand>, PermissionQueryHandler>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
