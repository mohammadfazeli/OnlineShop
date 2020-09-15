using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Web.Hubs
{
    public class Notification : Hub
    {
        private readonly IHttpContextAccessor _httpContext;

        public Notification(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public string connectionId { get; set; }

        public async Task SendNotification(string connectionId, string message)
        {
            await Clients.Client(connectionId: connectionId).SendAsync("SendNotification", message);
        }

        public string GetConnectionId()
        {
            var x = _httpContext.HttpContext.Connection.LocalIpAddress.ToString();
            return x;
            //   HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; //Context.ConnectionId; //"asd";//
        }
    }
}

public class test : HttpContext
{
    public override ConnectionInfo Connection => throw new NotImplementedException();

    public override IFeatureCollection Features => throw new NotImplementedException();

    public override IDictionary<object, object> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override HttpRequest Request => throw new NotImplementedException();

    public override CancellationToken RequestAborted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override IServiceProvider RequestServices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override HttpResponse Response => throw new NotImplementedException();

    public override ISession Session { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override string TraceIdentifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override ClaimsPrincipal User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override WebSocketManager WebSockets => throw new NotImplementedException();

    public override void Abort()
    {
        throw new NotImplementedException();
    }
}