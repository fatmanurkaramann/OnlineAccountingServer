using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Application.Services.CompanyServices;
using OnlineAccountingServer.Domain;
using OnlineAccountingServer.Domain.AppEntities.Identity;
using OnlineAccountingServer.Domain.Repositories.UCAFRepositories;
using OnlineAccountingServer.Persistance;
using OnlineAccountingServer.Persistance.Context;
using OnlineAccountingServer.Persistance.Repositories.UCAFRepositories;
using OnlineAccountingServer.Persistance.Services.AppServices;
using OnlineAccountingServer.Persistance.Services.CompanyServices;
using OnlineAccountingServer.Presantation;
using OnlineAccountingServer.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallService(builder.Configuration,typeof(IServiceInstaller).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
