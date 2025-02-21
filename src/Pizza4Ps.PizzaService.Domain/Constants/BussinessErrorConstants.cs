﻿namespace Pizza4Ps.PizzaService.Domain.Constants
{
    public static class BussinessErrorConstants
    {
        public class ProductOptionErrorConstant
        {
            public const string PRODUCTOPTION_NOT_FOUND = "Product option không tìm thấy";
        }
        public class StaffScheduleErrorConstant
        {
            public const string STAFFSCHEDULE_NOT_FOUND = "Lịch làm việc nhân viên không tìm thấy";
        }

        public class StaffZoneScheduleErrorConstant
        {
            public const string STAFFZONESCHEDULE_NOT_FOUND = "Lịch làm việc nhân viên theo khu vực không tìm thấy";
        }

        public class WorkingTimeErrorConstant
        {
            public const string WORKINGTIME_NOT_FOUND = "Working time không tìm thấy";
        }

        public class TableBookingErrorConstant
        {
            public const string TABLEBOOKING_NOT_FOUND = "Table booking không tìm thấy";
        }

        public class BookingErrorConstant
        {
            public const string BOOKING_NOT_FOUND = "Bàn đặt không tìm thấy";
        }

        public class OrderVoucherErrorConstant
        {
            public const string ORDERVOUCHER_NOT_FOUND = "Order voucher không tìm thấy";
        }

        public class CategoryErrorConstant
        {
            public const string CATEGORY_NOT_FOUND = "Danh mục không tìm thấy";
        }

        public class ProductErrorConstant
        {
            public const string PRODUCT_NOT_FOUND = "Món ăn không tìm thấy";
        }

        public class OrderItemErrorConstant
        {
            public const string ORDER_ITEM_CANNOT_DONE = "Order item không tìm thấy";
            public const string ORDER_ITEM_CANNOT_SERVED = "Món ăn không thể được phục vụ";
            public const string ORDER_ITEM_NOT_FOUND = "Món ăn không thể hoàn thành";

        }

        public class OrderItemDetailErrorConstant
        {
            public const string ORDER_ITEM_DETAIL_NOT_FOUND = "Order Item Detail không tìm thấy";
        }

        public class OptionItemErrorConstant
        {
            public const string OPTION_ITEM_NOT_FOUND = "lựa chọn không tìm thấy";
        }

        public class PaymentErrorConstant
        {
            public const string PAYMENT_NOT_FOUND = "Payment không tìm thấy";
        }

        public class CustomerErrorConstant
        {
            public const string CUSTOMER_NOT_FOUND = "Khách hàng không tìm thấy";
        }

        public class FeedbackErrorConstant
        {
            public const string FEEDBACK_NOT_FOUND = "Feedback không tìm thấy";
        }

        public class ZoneErrorConstant
        {
            public const string ZONE_NOT_FOUND = "Khu vực không tìm thấy";
        }

        public class OrderErrorConstant
        {
            public const string ORDER_NOT_FOUND = "Đơn hàng không tìm thấy";
            public const string ORDER_CANNOT_CHECK_OUT = "Đơn hàng đã được xuất hoá đơn hoặc thanh toán";
            public const string ORDER_CANNOT_PAY = "Đơn hàng chưa được check out hoặc đã được thanh toán";
            public const string ORDER_STATUS_INVALID_TO_ORDER = "Đơn hàng đã được xuất hoá đơn hoặc được thanh toán";
        }

        public class StaffErrorConstant
        {
            public const string STAFF_NOT_FOUND = "Nhân viên không tìm thấy";
        }

        public class OptionErrorConstant
        {
            public const string OPTION_NOT_FOUND = "Option không tìm thấy";
        }

        public class VoucherErrorConstant
        {
            public const string VOUCHER_NOT_FOUND = "Voucher không tìm thấy";
        }

        public class TableErrorConstant
        {
            public const string TABLE_NOT_FOUND = "Bàn không tìm thấy";
            public const string TABLE_NOT_HAVE_ORDER = "Bàn không có đơn hàng nào";
            public const string TABLE_ORDER_NOT_HAVE_ORDER_ITEM = "Đơn hàng không có món ăn nào";
            public const string INVALID_TABLE_STATUS = "Trạng thái bàn không hợp lệ";
            public const string TABLE_ORDER_NOT_HAVE_TOTAL_PRICE = "Đơn hàng chưa được tính tổng tiền";
        }

        public class StaffZoneErrorConstant
        {
            public const string STAFFZONE_NOT_FOUND = "Khu vực nhân viên không tìm thấy";
        }
    }
}
