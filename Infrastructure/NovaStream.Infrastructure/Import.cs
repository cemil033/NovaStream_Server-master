﻿global using System.Net;
global using System.Text;
global using System.Net.Mail;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.IdentityModel.Tokens.Jwt;

global using NovaStream.Application.Services;
global using NovaStream.Infrastructure.Utilities;
global using NovaStream.Domain.Entities.Concrete;

global using Amazon;
global using Amazon.S3;
global using Amazon.Runtime;
global using Amazon.S3.Model;
global using Amazon.S3.Transfer;
global using Azure.Storage.Blobs;
global using Azure.Storage.Blobs.Models;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
