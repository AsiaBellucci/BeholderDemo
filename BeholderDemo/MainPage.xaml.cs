
//using AndroidX.Lifecycle;
using BeholderDemo.Models;
using BeholderDemo.Services;
using BeholderDemo.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Datasync.Client;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AuthenticationToken = Microsoft.Datasync.Client.AuthenticationToken;

namespace BeholderDemo;
public partial class MainPage : ContentPage
{
    public AuthService AuthService { get; }

    public MainPage()
    {
        InitializeComponent();
        
    }

    public void Login(object sender, EventArgs args)
    {
        var authService = new AuthService(); // most likely you will inject it in constructor, but for simplicity let's initialize it here
        var result =  authService.LoginAsync(CancellationToken.None).Result;
        var token = result?.IdToken; // you can also get AccessToken if you need it
        if (token != null)
        {
            Token.Text = token;
            var handler = new JwtSecurityTokenHandler();
            var data = handler.ReadJwtToken(token);
            var claims = data.Claims.ToList();
            if (data != null)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($"Name: {data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value}");
                stringBuilder.AppendLine($"Email: {data.Claims.FirstOrDefault(x => x.Type.Equals("preferred_username"))?.Value}");
                LoginResultLabel.Text = stringBuilder.ToString();
            }
        }
    }
}

