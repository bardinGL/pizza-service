﻿using Pizza4Ps.PizzaService.API.Middlewares;

namespace Pizza4Ps.PizzaService.API.Setup
{
    public static class MiddlewareRegistery
    {
        public static IApplicationBuilder MiddlewareRegisteryMethod(this IApplicationBuilder app)
        {
            //app.UseCors("AllowAll");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger"; // Cấu hình để Swagger UI chạy tại /swagger
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandler>();
            app.UseCors("AllowAll");
            return app;
        }
    }
}
