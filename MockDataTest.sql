USE [clothesstoremgt]
GO

-- 1. Bảng Categories (10 danh mục)
INSERT INTO [dbo].[Categories] ([CategoryName], [Description]) VALUES 
(N'Áo thun nam', N'Áo thun cộc tay, dài tay nam'),
(N'Áo sơ mi nam', N'Sơ mi công sở, sơ mi casual'),
(N'Quần Jeans nam', N'Quần ống rộng, ống suông'),
(N'Quần Kaki nam', N'Quần Kaki co giãn thoải mái'),
(N'Áo thun nữ', N'Áo croptop, áo thun basic'),
(N'Áo sơ mi nữ', N'Sơ mi kiểu Hàn Quốc'),
(N'Chân váy', N'Chân váy chữ A, xếp ly'),
(N'Đầm (Dress)', N'Đầm dự tiệc, dạo phố'),
(N'Áo khoác', N'Áo khoác da, gió, hoodie'),
(N'Phụ kiện', N'Mũ, thắt lưng, tất/vớ');

-- 2. Bảng Colors (10 màu)
INSERT INTO [dbo].[Colors] ([ColorName]) VALUES 
(N'Trắng'), (N'Đen'), (N'Đỏ'), (N'Xanh dương'), (N'Xanh lá'), 
(N'Vàng'), (N'Hồng'), (N'Xám'), (N'Nâu'), (N'Be');

-- 3. Bảng Sizes (6 size)
INSERT INTO [dbo].[Sizes] ([SizeName]) VALUES 
(N'XS'), (N'S'), (N'M'), (N'L'), (N'XL'), (N'XXL');

-- 4. Bảng Suppliers (5 nhà cung cấp)
INSERT INTO [dbo].[Suppliers] ([SupplierName], [PhoneNumber]) VALUES 
(N'Xưởng may Bảo Minh', '0901112233'),
(N'Công ty TNHH Dệt may Phong Phú', '0912223344'),
(N'Xí nghiệp may Gia Định', '0923334455'),
(N'Đại lý nhập khẩu Quảng Châu', '0934445566'),
(N'Xưởng VNXK Thành Đạt', '0945556677');

-- 5. Bảng ShippingProviders (3 đơn vị vận chuyển)
INSERT INTO [dbo].[ShippingProviders] ([Name], [PhoneNumber], [Address], [IsActive]) VALUES 
(N'Giao Hàng Nhanh (GHN)', '19001234', N'Trụ sở chính TP.HCM', 1),
(N'Giao Hàng Tiết Kiệm (GHTK)', '19005678', N'Chi nhánh miền Nam', 1),
(N'Viettel Post', '19009999', N'Toàn quốc', 1);

-- 6. Bảng Products (30 sản phẩm)
INSERT INTO [dbo].[Products] ([ProductName], [Description], [CategoryID]) VALUES 
(N'Áo thun nam Cổ Tròn Basic', N'Chất cotton 100%', 1), (N'Áo thun nam Oversize Print', N'In họa tiết Local Brand', 1),
(N'Áo Polo nam sọc ngang', N'Form regular fit', 1), (N'Sơ mi nam tay ngắn Linen', N'Chất đũi mát mẻ', 2),
(N'Sơ mi nam Oxford tay dài', N'Chống nhăn cao cấp', 2), (N'Sơ mi nam họa tiết Tropical', N'Mặc đi biển', 2),
(N'Quần Jeans nam Slimfit', N'Co giãn 4 chiều', 3), (N'Quần Jeans nam Skinny Rách', N'Phong cách đường phố', 3),
(N'Quần Jeans nam Straight Đen', N'Đen trơn dễ phối đồ', 3), (N'Quần Kaki nam túi hộp (Cargo)', N'Dáng thể thao', 4),
(N'Quần Kaki nam dáng đứng Be', N'Lịch lãm công sở', 4), (N'Quần Short Kaki nam', N'Ngắn ngang gối', 4),
(N'Áo thun nữ Croptop trơn', N'Ôm body tôn dáng', 5), (N'Áo thun nữ Form rộng Graphic', N'Hình in dễ thương', 5),
(N'Áo thun nữ tay dài dệt kim', N'Mặc tiết trời thu', 5), (N'Sơ mi lụa nữ cổ V', N'Sang trọng quyến rũ', 6),
(N'Sơ mi nữ kiểu tay bồng', N'Tiểu thư', 6), (N'Sơ mi nữ voan hoa nhí', N'Phong cách vintage', 6),
(N'Chân váy chữ A dáng ngắn', N'Tôn chiều cao', 7), (N'Chân váy Midi xếp ly dài', N'Mềm mại nữ tính', 7),
(N'Chân váy Denim xẻ tà', N'Cá tính năng động', 7), (N'Đầm Maxi hoa dạo biển', N'Vải voan bay bổng', 8),
(N'Đầm Body dự tiệc đính đá', N'Lấp lánh sang trọng', 8), (N'Đầm babydoll thắt nơ', N'Dáng xòe giấu vòng 2', 8),
(N'Áo khoác da Biker nam', N'Dày dặn giữ ấm', 9), (N'Áo gió chống nước Unisex', N'Gọn nhẹ tiện lợi', 9),
(N'Áo khoác Cardigan len nữ', N'Len tăm Quảng Châu', 9), (N'Mũ lưỡi trai thêu logo NY', N'Chất kaki', 10),
(N'Thắt lưng da nam khóa cài', N'Da bò thật 100%', 10), (N'Set 3 đôi tất cotton', N'Thấm hút mồ hôi', 10);

-- 7. Bảng ProductVariants (Giả định mỗi Product có 1 biến thể đại diện để test)
INSERT INTO [dbo].[ProductVariants] ([ProductID], [ColorID], [SizeID], [SKU], [Price], [AmountInStock], [Img]) VALUES 
(1, 1, 3, N'PRD01-W-M', 150000, 50, N'img1.jpg'), (2, 2, 4, N'PRD02-B-L', 180000, 30, N'img2.jpg'),
(3, 3, 5, N'PRD03-R-XL', 250000, 20, N'img3.jpg'), (4, 4, 3, N'PRD04-BL-M', 300000, 15, N'img4.jpg'),
(5, 1, 4, N'PRD05-W-L', 350000, 40, N'img5.jpg'), (6, 5, 5, N'PRD06-G-XL', 280000, 10, N'img6.jpg'),
(7, 4, 3, N'PRD07-BL-M', 450000, 60, N'img7.jpg'), (8, 2, 2, N'PRD08-B-S', 480000, 25, N'img8.jpg'),
(9, 2, 4, N'PRD09-B-L', 420000, 35, N'img9.jpg'), (10, 8, 5, N'PRD10-GR-XL', 380000, 45, N'img10.jpg'),
(11, 10, 3, N'PRD11-BE-M', 350000, 50, N'img11.jpg'), (12, 9, 4, N'PRD12-BR-L', 220000, 80, N'img12.jpg'),
(13, 1, 2, N'PRD13-W-S', 120000, 100, N'img13.jpg'), (14, 7, 3, N'PRD14-P-M', 160000, 60, N'img14.jpg'),
(15, 6, 2, N'PRD15-Y-S', 200000, 15, N'img15.jpg'), (16, 1, 3, N'PRD16-W-M', 280000, 25, N'img16.jpg'),
(17, 7, 2, N'PRD17-P-S', 320000, 30, N'img17.jpg'), (18, 5, 4, N'PRD18-G-L', 290000, 40, N'img18.jpg'),
(19, 2, 2, N'PRD19-B-S', 250000, 55, N'img19.jpg'), (20, 10, 3, N'PRD20-BE-M', 300000, 45, N'img20.jpg'),
(21, 4, 4, N'PRD21-BL-L', 350000, 35, N'img21.jpg'), (22, 6, 3, N'PRD22-Y-M', 450000, 20, N'img22.jpg'),
(23, 2, 2, N'PRD23-B-S', 650000, 10, N'img23.jpg'), (24, 7, 4, N'PRD24-P-L', 380000, 15, N'img24.jpg'),
(25, 2, 5, N'PRD25-B-XL', 850000, 8, N'img25.jpg'), (26, 8, 4, N'PRD26-GR-L', 350000, 25, N'img26.jpg'),
(27, 9, 3, N'PRD27-BR-M', 280000, 30, N'img27.jpg'), (28, 2, 3, N'PRD28-B-M', 120000, 150, N'img28.jpg'),
(29, 9, 4, N'PRD29-BR-L', 250000, 80, N'img29.jpg'), (30, 1, 2, N'PRD30-W-S', 80000, 200, N'img30.jpg');

-- 8. Bảng Orders (30 Đơn hàng) 
-- Enum Int OrderStatus: 0=Chờ duyệt, 1=Đang giao, 2=Hoàn thành, 3=Đã hủy
INSERT INTO [dbo].[Orders] ([CustomerID], [OrderDate], [OrderStatus], [ShippingAddress], [ReceiverName], [ReceiverPhone], [TotalMoney], [ShippingProviderID], [EmployeeID]) VALUES 
(NULL, '2026-04-01 10:15:00', 2, N'Quận 1, TP.HCM', N'Nguyễn Văn A', '0901112222', 450000, 1, NULL),
(NULL, '2026-04-02 14:30:00', 2, N'Quận 2, TP.HCM', N'Trần Thị B', '0903334444', 700000, 2, NULL),
(NULL, '2026-04-03 09:20:00', 2, N'Quận 3, TP.HCM', N'Lê Văn C', '0905556666', 120000, 1, NULL),
(NULL, '2026-04-04 16:45:00', 2, N'Quận 4, TP.HCM', N'Phạm Thị D', '0907778888', 650000, 3, NULL),
(NULL, '2026-04-05 11:10:00', 3, N'Quận 5, TP.HCM', N'Hoàng Văn E', '0909990000', 350000, 2, NULL),
(NULL, '2026-04-06 18:00:00', 2, N'Quận 6, TP.HCM', N'Vũ Thị F', '0911112222', 880000, 1, NULL),
(NULL, '2026-04-07 08:30:00', 2, N'Quận 7, TP.HCM', N'Đặng Văn G', '0913334444', 250000, 3, NULL),
(NULL, '2026-04-08 13:25:00', 2, N'Quận 8, TP.HCM', N'Bùi Thị H', '0915556666', 1200000, 2, NULL),
(NULL, '2026-04-09 19:15:00', 1, N'Quận 9, TP.HCM', N'Đỗ Văn I', '0917778888', 280000, 1, NULL),
(NULL, '2026-04-10 10:40:00', 2, N'Quận 10, TP.HCM', N'Hồ Thị K', '0919990000', 450000, 1, NULL),
(NULL, '2026-04-11 15:50:00', 2, N'Quận 11, TP.HCM', N'Ngô Văn L', '0921112222', 300000, 3, NULL),
(NULL, '2026-04-12 09:05:00', 2, N'Quận 12, TP.HCM', N'Dương Thị M', '0923334444', 950000, 2, NULL),
(NULL, '2026-04-13 17:30:00', 3, N'Bình Thạnh, TP.HCM', N'Lý Văn N', '0925556666', 160000, 1, NULL),
(NULL, '2026-04-14 12:20:00', 1, N'Tân Bình, TP.HCM', N'Đinh Thị P', '0927778888', 500000, 2, NULL),
(NULL, '2026-04-15 14:10:00', 2, N'Gò Vấp, TP.HCM', N'Châu Văn Q', '0929990000', 420000, 1, NULL),
(NULL, '2026-04-16 08:55:00', 2, N'Phú Nhuận, TP.HCM', N'Lâm Thị R', '0931112222', 180000, 3, NULL),
(NULL, '2026-04-17 20:45:00', 2, N'Tân Phú, TP.HCM', N'Tôn Văn S', '0933334444', 680000, 2, NULL),
(NULL, '2026-04-18 11:35:00', 2, N'Bình Tân, TP.HCM', N'Trịnh Thị T', '0935556666', 220000, 1, NULL),
(NULL, '2026-04-19 16:15:00', 1, N'Thủ Đức, TP.HCM', N'Mạch Văn U', '0937778888', 850000, 1, NULL),
(NULL, '2026-04-20 10:00:00', 0, N'Nhà Bè, TP.HCM', N'Lương Thị V', '0939990000', 290000, 2, NULL),
(NULL, '2026-04-20 13:40:00', 2, N'Hóc Môn, TP.HCM', N'Đoàn Văn X', '0941112222', 150000, 3, NULL),
(NULL, '2026-04-21 09:10:00', 2, N'Bình Chánh, TP.HCM', N'Phan Thị Y', '0943334444', 530000, 1, NULL),
(NULL, '2026-04-22 18:25:00', 0, N'Củ Chi, TP.HCM', N'Mai Văn Z', '0945556666', 380000, 2, NULL),
(NULL, '2026-04-23 14:50:00', 1, N'Quận 1, TP.HCM', N'Thái Thị W', '0947778888', 740000, 1, NULL),
(NULL, '2026-04-24 11:20:00', 2, N'Quận 3, TP.HCM', N'Vương Văn K', '0949990000', 320000, 3, NULL),
(NULL, '2026-04-24 15:30:00', 0, N'Quận 4, TP.HCM', N'Tạ Thị L', '0951112222', 450000, 2, NULL),
(NULL, '2026-04-25 09:45:00', 0, N'Quận 5, TP.HCM', N'Kiều Văn M', '0953334444', 120000, 1, NULL),
(NULL, '2026-04-25 12:15:00', 1, N'Quận 7, TP.HCM', N'Diệp Thị N', '0955556666', 650000, 1, NULL),
(NULL, '2026-04-25 16:00:00', 0, N'Quận 10, TP.HCM', N'Chử Văn P', '0957778888', 250000, 2, NULL),
(NULL, '2026-04-25 19:30:00', 0, N'Gò Vấp, TP.HCM', N'Cát Thị Q', '0959990000', 300000, 3, NULL);

-- 9. Bảng OrderDetails (40 chi tiết đơn)
INSERT INTO [dbo].[OrderDetails] ([OrderID], [VariantID], [Quantity], [PriceAtPurchase]) VALUES 
(1, 7, 1, 450000), (2, 5, 2, 350000), (3, 13, 1, 120000), (4, 23, 1, 650000),
(5, 11, 1, 350000), (6, 25, 1, 850000), (6, 30, 1, 30000), (7, 19, 1, 250000),
(8, 22, 2, 450000), (8, 20, 1, 300000), (9, 27, 1, 280000), (10, 7, 1, 450000),
(11, 20, 1, 300000), (12, 25, 1, 850000), (12, 30, 1, 100000), (13, 14, 1, 160000),
(14, 1, 2, 150000), (14, 15, 1, 200000), (15, 9, 1, 420000), (16, 2, 1, 180000),
(17, 22, 1, 450000), (17, 12, 1, 230000), (18, 12, 1, 220000), (19, 4, 1, 300000),
(19, 21, 1, 350000), (19, 15, 1, 200000), (20, 18, 1, 290000), (21, 1, 1, 150000),
(22, 17, 1, 320000), (22, 12, 1, 210000), (23, 10, 1, 380000), (24, 7, 1, 450000),
(24, 18, 1, 290000), (25, 17, 1, 320000), (26, 7, 1, 450000), (27, 28, 1, 120000),
(28, 23, 1, 650000), (29, 3, 1, 250000), (30, 20, 1, 300000), (1, 28, 1, 120000);

-- 10. Bảng Invoices (30 hóa đơn) 
-- Enum String PaymentMethod, Enum Int Status (0-3 dựa theo CHECK Constraint)
INSERT INTO [dbo].[Invoices] ([OrderID], [Amount], [PaymentDate], [PaymentMethod], [TransactionID], [Status]) VALUES 
(1, 450000, '2026-04-01', N'CASH', NULL, 2), (2, 700000, '2026-04-02', N'CREDIT_CARD', N'TXN001', 2),
(3, 120000, '2026-04-03', N'E_WALLET', N'MOMO001', 2), (4, 650000, '2026-04-04', N'CASH', NULL, 2),
(5, 350000, '2026-04-05', N'CREDIT_CARD', N'TXN002', 3), (6, 880000, '2026-04-06', N'CASH', NULL, 2),
(7, 250000, '2026-04-07', N'E_WALLET', N'ZALO001', 2), (8, 1200000, '2026-04-08', N'CREDIT_CARD', N'TXN003', 2),
(9, 280000, '2026-04-09', N'CASH', NULL, 1), (10, 450000, '2026-04-10', N'CREDIT_CARD', N'TXN004', 2),
(11, 300000, '2026-04-11', N'E_WALLET', N'MOMO002', 2), (12, 950000, '2026-04-12', N'CASH', NULL, 2),
(13, 160000, '2026-04-13', N'CREDIT_CARD', N'TXN005', 3), (14, 500000, '2026-04-14', N'E_WALLET', N'VNPAY001', 1),
(15, 420000, '2026-04-15', N'CASH', NULL, 2), (16, 180000, '2026-04-16', N'CREDIT_CARD', N'TXN006', 2),
(17, 680000, '2026-04-17', N'CASH', NULL, 2), (18, 220000, '2026-04-18', N'E_WALLET', N'MOMO003', 2),
(19, 850000, '2026-04-19', N'CREDIT_CARD', N'TXN007', 1), (20, 290000, '2026-04-20', N'CASH', NULL, 0),
(21, 150000, '2026-04-20', N'E_WALLET', N'ZALO002', 2), (22, 530000, '2026-04-21', N'CREDIT_CARD', N'TXN008', 2),
(23, 380000, '2026-04-22', N'CASH', NULL, 0), (24, 740000, '2026-04-23', N'E_WALLET', N'MOMO004', 1),
(25, 320000, '2026-04-24', N'CREDIT_CARD', N'TXN009', 2), (26, 450000, '2026-04-24', N'CASH', NULL, 0),
(27, 120000, '2026-04-25', N'E_WALLET', N'VNPAY002', 0), (28, 650000, '2026-04-25', N'CREDIT_CARD', N'TXN010', 1),
(29, 250000, '2026-04-25', N'CASH', NULL, 0), (30, 300000, '2026-04-25', N'E_WALLET', NULL, 0);

-- 11. Bảng WarehouseReceipts (10 Phiếu nhập kho)
INSERT INTO [dbo].[WarehouseReceipts] ([SupplierID], [EmployeeID], [ImportDate], [TotalAmount], [Status]) VALUES 
(1, NULL, '2026-03-01', 5000000, 1), (2, NULL, '2026-03-05', 8500000, 1),
(3, NULL, '2026-03-10', 3200000, 1), (4, NULL, '2026-03-15', 12000000, 1),
(5, NULL, '2026-03-20', 4500000, 1), (1, NULL, '2026-04-02', 6000000, 1),
(2, NULL, '2026-04-10', 7200000, 1), (3, NULL, '2026-04-18', 2800000, 1),
(4, NULL, '2026-04-22', 9000000, 0), (5, NULL, '2026-04-25', 3500000, 0);

-- 12. Bảng WarehouseReceiptDetails (20 Chi tiết nhập kho)
INSERT INTO [dbo].[WarehouseReceiptDetails] ([ReceiptID], [VariantID], [Quantity], [ImportPrice]) VALUES 
(1, 1, 50, 80000), (1, 2, 30, 100000), (2, 4, 15, 180000), (2, 5, 40, 200000),
(3, 7, 60, 250000), (4, 10, 45, 200000), (4, 12, 80, 120000), (5, 13, 100, 60000),
(6, 16, 25, 150000), (6, 18, 40, 160000), (7, 21, 35, 180000), (8, 25, 8, 500000),
(9, 28, 150, 50000), (9, 29, 80, 120000), (10, 30, 200, 40000), (1, 3, 20, 150000),
(2, 6, 10, 160000), (3, 8, 25, 280000), (4, 9, 35, 220000), (5, 14, 60, 80000);

-- 13. Bảng InventoryTransactions (30 Lịch sử xuất nhập)
-- Enum String TransactionType
INSERT INTO [dbo].[InventoryTransactions] ([VariantID], [TransactionType], [QuantityChange], [OrderID], [ReceiptID], [CreatedAt]) VALUES 
(1, N'IMPORT', 50, NULL, 1, '2026-03-01'), (2, N'IMPORT', 30, NULL, 1, '2026-03-01'),
(4, N'IMPORT', 15, NULL, 2, '2026-03-05'), (5, N'IMPORT', 40, NULL, 2, '2026-03-05'),
(7, N'IMPORT', 60, NULL, 3, '2026-03-10'), (10, N'IMPORT', 45, NULL, 4, '2026-03-15'),
(12, N'IMPORT', 80, NULL, 4, '2026-03-15'), (13, N'IMPORT', 100, NULL, 5, '2026-03-20'),
(7, N'EXPORT', -1, 1, NULL, '2026-04-01'), (5, N'EXPORT', -2, 2, NULL, '2026-04-02'),
(13, N'EXPORT', -1, 3, NULL, '2026-04-03'), (23, N'EXPORT', -1, 4, NULL, '2026-04-04'),
(11, N'EXPORT', -1, 5, NULL, '2026-04-05'), (25, N'EXPORT', -1, 6, NULL, '2026-04-06'),
(19, N'EXPORT', -1, 7, NULL, '2026-04-07'), (22, N'EXPORT', -2, 8, NULL, '2026-04-08'),
(27, N'EXPORT', -1, 9, NULL, '2026-04-09'), (7, N'EXPORT', -1, 10, NULL, '2026-04-10'),
(20, N'EXPORT', -1, 11, NULL, '2026-04-11'), (25, N'EXPORT', -1, 12, NULL, '2026-04-12'),
(14, N'EXPORT', -1, 13, NULL, '2026-04-13'), (1, N'EXPORT', -2, 14, NULL, '2026-04-14'),
(9, N'EXPORT', -1, 15, NULL, '2026-04-15'), (2, N'EXPORT', -1, 16, NULL, '2026-04-16'),
(22, N'EXPORT', -1, 17, NULL, '2026-04-17'), (12, N'EXPORT', -1, 18, NULL, '2026-04-18'),
(4, N'EXPORT', -1, 19, NULL, '2026-04-19'), (18, N'EXPORT', -1, 20, NULL, '2026-04-20'),
(1, N'RETURN', 1, 14, NULL, '2026-04-21'), (12, N'ADJUSTMENT', -5, NULL, NULL, '2026-04-22');

-- 14. Bảng CustomerService (15 Ticket hỗ trợ)
INSERT INTO [dbo].[CustomerService] ([CustomerID], [Reason], [Date], [Status], [EmployeeID]) VALUES 
(NULL, N'Hàng bị lỗi chỉ', '2026-04-10', 1, NULL), (NULL, N'Yêu cầu đổi size áo', '2026-04-12', 1, NULL),
(NULL, N'Giao nhầm màu', '2026-04-15', 1, NULL), (NULL, N'Thái độ shipper không tốt', '2026-04-16', 0, NULL),
(NULL, N'Hỏi về chính sách bảo hành', '2026-04-18', 1, NULL), (NULL, N'Xin đổi địa chỉ giao hàng', '2026-04-19', 1, NULL),
(NULL, N'Mã giảm giá không hoạt động', '2026-04-20', 1, NULL), (NULL, N'Đơn hàng bị giao trễ', '2026-04-21', 0, NULL),
(NULL, N'Yêu cầu xuất hóa đơn đỏ', '2026-04-22', 0, NULL), (NULL, N'Sản phẩm không giống hình', '2026-04-23', 0, NULL),
(NULL, N'Hỏi về size chart quần Jeans', '2026-04-23', 1, NULL), (NULL, N'Chưa nhận được tiền hoàn', '2026-04-24', 0, NULL),
(NULL, N'Lỗi thanh toán Momo', '2026-04-24', 0, NULL), (NULL, N'Muốn làm khách sỉ', '2026-04-25', 0, NULL),
(NULL, N'Phản ánh chất lượng vải', '2026-04-25', 0, NULL);