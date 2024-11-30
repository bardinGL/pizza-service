﻿namespace Pizza4Ps.PizzaService.Persistence.Constants
{
    internal class TableNames
    {
        // *********** Plural Nouns *
        //internal const string Actions = nameof(Actions);
        //internal const string Functions = nameof(Functions);
        //internal const string ActionInFunctions = nameof(ActionInFunctions);
        //internal const string Permissions = nameof(Permissions);

        internal const string AppUsers = nameof(AppUsers);
        internal const string AppRoles = nameof(AppRoles);
        internal const string AppUserRoles = nameof(AppUserRoles);

        internal const string AppUserClaims = nameof(AppUserClaims); // IdentityUserClaim
        internal const string AppRoleClaims = nameof(AppRoleClaims); // IdentityRoleClaim
        internal const string AppUserLogins = nameof(AppUserLogins); // IdentityRoleClaim
        internal const string AppUserTokens = nameof(AppUserTokens); // IdentityUserToken

        internal const string Product = nameof(Product);
        internal const string Category = nameof(Category);
        internal const string Order = nameof(Order);
        internal const string OrderItem = nameof(OrderItem);

    }
}
