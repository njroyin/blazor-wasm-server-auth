using BlazorWasmServerAuth.Client.Models;
using BlazorWasmServerAuth.Kernel;
using FreeSql.Extensions.EntityUtil;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasmServerAuth.Client;
 
/// <summary>
/// 权限认证
/// </summary>
public class MyAuthenticationStateProvider : AuthenticationStateProvider
{
    /// <summary>
    /// 定义访问指定数据连接
    /// </summary>
    private IFreeSql<DbMainFlag> freeSql = App.GetService<IFreeSql<DbMainFlag>>();
     
    public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
        return await Task.FromResult(new AuthenticationState(AnonymousUser));
    }

    //Anonymous user can has no claims but requires an empty identity
    private ClaimsPrincipal AnonymousUser => new(new ClaimsIdentity(Array.Empty<Claim>()));
    // private ClaimsPrincipal FakedUser {
    //     get {
    //         var claims = new[] {
    //             new Claim(ClaimTypes.Name, "john"),
    //             new Claim(ClaimTypes.Role, "user"), 
    //             
    //         };
    //         var identity = new ClaimsIdentity(claims, "faked");
    //         return new ClaimsPrincipal(identity);
    //     }
    // }

    private ClaimsPrincipal BuildUser(User user)
    {
        var claims = new[] {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, "user"), 
            new Claim(ClaimTypes.Sid, $"{user.Id}"), 
        };
        var identity = new ClaimsIdentity(claims, "faked");
        return new ClaimsPrincipal(identity);
    }

    public  void FakedSignIn(string code,string password)
    {  
       var user = freeSql.Select<User>().Where(w => w.Code == code).ToOne();

       if (user == null)
       {
           throw new Exception("未找到用户");
       }

       if (user.Password != password)
       {
           throw new Exception("密码错误");
       }

       var result = Task.FromResult(new AuthenticationState(BuildUser(user)));
        NotifyAuthenticationStateChanged(result);
    }
    
   
    public void FakedSignOut() {
        var result = Task.FromResult(new AuthenticationState(AnonymousUser));
        NotifyAuthenticationStateChanged(result);
    }
 
}
