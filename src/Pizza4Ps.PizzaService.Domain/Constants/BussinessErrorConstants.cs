namespace Pizza4Ps.PizzaService.Domain.Constants
{
    public static class BussinessErrorConstants
    {
        public class AdditionalFeeErrorConstant
        {
            public const string VALUE_INVALID = "Amount cannot be negative";
            public const string ADDITIONAL_FEE_NOT_FOUND = "Additional fee not found";
        }

        public class WorkingSlotRegisterErrorConstant
        {
            public const string INVALID_WORKING_SLOT_REGISTER_STATUS = "Working slot register status is invalid";
            public const string WORKING_SLOT_REGISTER_NOT_FOUND = "Working slot register not found";
            public const string WORKING_SLOT_REGISTER_ALREADY_APPROVED = "Working slot register has already been approved";
            public const string WORKING_SLOT_REGISTER_ALREADY_REJECTED = "Working slot register has already been rejected";
        }

        public class SwapWorkingSlotErrorConstant
        {
            public const string SWAP_WORKING_SLOT_ALREADY_REJECTED = "Swap working slot request has already been rejected";
            public const string SWAP_WORKING_SLOT_ALREADY_PENDING_APPROVE = "Swap working slot request is pending manager approval";
            public const string SWAP_WORKING_SLOT_ALREADY_APPROVED = "Swap working slot request has already been approved";
            public const string SWAP_WORKING_SLOT_NOT_FOUND = "Swap working slot request not found";
            public const string SWAP_WORKING_SLOT_INVALID_STATE = "Cannot reject a request that is not pending";
        }

        public class ConfigErrorConstant
        {
            public const string CONFIG_NOT_FOUND = "Config not found";
            public const string CONFIG_INVALID = "Config is invalid";
        }

        public class RoleErrorConstant
        {
            public const string ROLE_NOT_FOUND = "Role not found";
        }

        public class WorkingSlotErrorConstant
        {
            public const string WORKING_SLOT_NOT_FOUND = "Working slot not found";
            public const string ALREADY_REGISTERED = "Employee has already registered for this working slot";
        }

        public class ShiftErrorConstant
        {
            public const string SHIFT_NOT_FOUND = "Shift not found";
        }

        public class CurrentOrderIdExisted
        {
            public const string CURRENT_ORDER_ID_EXISTED = "Table already has an existing order ID";
        }

        public class ProductOptionErrorConstant
        {
            public const string PRODUCTOPTION_NOT_FOUND = "Product option not found";
        }

        public class DayErrorConstant
        {
            public const string DAY_NOT_FOUND = "Day of week not found";
        }

        public class StaffScheduleErrorConstant
        {
            public const string STAFFSCHEDULE_NOT_FOUND = "Staff schedule not found";
        }

        public class IngredientErrorConstant
        {
            public const string INGREDIENT_NOT_FOUND = "Ingredient not found";
        }

        public class StaffZoneScheduleErrorConstant
        {
            public const string STAFF_ZONE_SCHEDULE_NOT_FOUND = "Staff zone schedule not found";
        }

        public class WorkingTimeErrorConstant
        {
            public const string WORKINGTIME_NOT_FOUND = "Working time not found";
        }
        public class TableBookingErrorConstant
        {
            public const string TABLEBOOKING_NOT_FOUND = "Table booking not found";
        }

        public class SizeErrorConstant
        {
            public const string SIZE_NOT_FOUND = "Pizza size not found";
        }

        public class BookingErrorConstant
        {
            public const string BOOKING_NOT_FOUND = "Reservation not found";
            public const string BOOKING_SLOT_FULL = "No available tables at this time";
            public const string INVALID_BOOKING_STATUS = "Invalid reservation status";
            public const string INVALID_BOOKING_CAPACITY = "Guest count exceeds table capacity";
            public const string NOT_ASSIGNED_TABLE = "Table not yet assigned";
        }

        public class BookingSlotErrorConstant
        {
            public const string BOOKING_SLOT_NOT_FOUND = "This time slot is unavailable for booking";
        }

        public class OrderVoucherErrorConstant
        {
            public const string ORDERVOUCHER_NOT_FOUND = "Order voucher not found";
        }

        public class CategoryErrorConstant
        {
            public const string CATEGORY_NOT_FOUND = "Category not found";
        }

        public class ProductErrorConstant
        {
            public const string PRODUCT_NOT_FOUND = "Product not found";
            public const string INVALID_PRODUCT_TYPE= "Invalid product type";
        }

        public class ProductSizeErrorConstant
        {
            public const string PRODUCTSIZE_NOT_FOUND = "Product size not found";
            public const string PRODUCTSIZE_EXISTED = "Product size already exists";
        }

        public class RecipeErrorConstant
        {
            public const string RECIPE_NOT_FOUND = "Recipe not found";
            public const string RECIPE_NOT_INCLUDED_INGREDIENT = "Recipe must include either ingredient ID or name";
            public const string RECIPE_UNIT_INVALID = "Invalid unit of measurement";
        }

        public class OrderItemErrorConstant
        {
            public const string INVALID_ORDER_ITEM_STATUS = "Invalid order item status";
            public const string ORDER_ITEM_CANNOT_DONE = "Order item cannot be completed";
            public const string ORDER_ITEM_CANNOT_SERVED = "Order item cannot be served";
            public const string ORDER_ITEM_NOT_FOUND = "Order item not found";
        }

        public class OrderItemDetailErrorConstant
        {
            public const string ORDER_ITEM_DETAIL_NOT_FOUND = "Order item detail not found";
        }

        public class OptionItemErrorConstant
        {
            public const string OPTION_ITEM_NOT_FOUND = "Option item not found";
        }

        public class PaymentErrorConstant
        {
            public const string PAYMENT_NOT_FOUND = "Payment not found";
        }

        public class CustomerErrorConstant
        {
            public const string CUSTOMER_NOT_FOUND = "Customer not found";
        }

        public class FeedbackErrorConstant
        {
            public const string FEEDBACK_NOT_FOUND = "Feedback not found";
        }

        public class OrderErrorConstant
        {
            public const string ORDER_NOT_FOUND = "Order not found";
            public const string ORDER_CANNOT_CHECK_OUT = "Order has already been invoiced or paid";
            public const string ORDER_CANNOT_CANCEL_CHECK_OUT = "Order has not been invoiced or paid yet";
            public const string ORDER_CANNOT_PAY = "Order has not been checked out or has already been paid";
            public const string ORDER_STATUS_INVALID_TO_ORDER = "Order has already been invoiced or paid";
        }

        public class StaffErrorConstant
        {
            public const string STAFF_NOT_FOUND = "Staff not found";
            public const string INVALID_STAFF_STATUS = "Invalid staff status";
            public const string INVALID_STAFF_TYPE = "Invalid staff type";
        }

        public class OptionErrorConstant
        {
            public const string OPTION_NOT_FOUND = "Option not found";
        }

        public class StaffZoneErrorConstant
        {
            public const string STAFFZONE_NOT_FOUND = "Staff zone not found";
        }

        public class TableErrorConstant
        {
            public const string TABLE_NOT_FOUND = "Table not found";
            public const string TABLE_NOT_HAVE_ORDER = "Table has no active order";
            public const string TABLE_ORDER_NOT_HAVE_ORDER_ITEM = "Order contains no items";
            public const string INVALID_TABLE_STATUS = "Invalid table status";
            public const string TABLE_ORDER_NOT_HAVE_TOTAL_PRICE = "Order total has not been calculated";
            public const string CAPACITY_INVALID = "Table capacity must be greater than 0";
        }

        public class VoucherErrorConstant
        {
            public const string VOUCHER_NOT_FOUND = "Voucher not found";
            public const string INVALID_VOUCHER_DISCOUNT_TYPE = "Voucher discount type is invalid";
        }

        public class VoucherTypeErrorConstant
        {
            public const string TOTAL_QUANTITY_INVALID = "Total quantity must be greater than 0";
            public const string VOUCHER_TYPE_NOT_FOUND = "Voucher type not found";
        }

        public class ZoneErrorConstant
        {
            public const string ZONE_NOT_FOUND = "Zone not found";
        }
    }
}
