using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Constants
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

		internal const string Booking = nameof(Booking);
		internal const string Category = nameof(Category);
		internal const string Config = nameof(Config);
		internal const string Customer = nameof(Customer);
		internal const string FeedBack = nameof(FeedBack);
		internal const string Notification = nameof(Notification);
		internal const string Option = nameof(Option);
		internal const string OptionItem = nameof(OptionItem);
		internal const string OptionItemOrderItem = nameof(OptionItemOrderItem);
		internal const string Order = nameof(Order);
		internal const string OrderInTable = nameof(OrderInTable);
		internal const string OrderItem = nameof(OrderItem);
		internal const string OrderVoucher = nameof(OrderVoucher);
		internal const string Payment = nameof(Payment);
		internal const string Product = nameof(Product);
		internal const string ProductOption = nameof(ProductOption);
		internal const string ScheduleConfig = nameof(ScheduleConfig);
		internal const string Staff = nameof(Staff);
		internal const string StaffZoneSchedule = nameof(StaffZoneSchedule);
		internal const string StaffScheduleLog = nameof(StaffScheduleLog);
		internal const string StaffZone = nameof(StaffZone);
		internal const string Table = nameof(Table);
		internal const string TableBooking = nameof(TableBooking);
		internal const string Voucher = nameof(Voucher);
		internal const string WorkingTime = nameof(WorkingTime);
		internal const string Zone = nameof(Zone);
	}
}
