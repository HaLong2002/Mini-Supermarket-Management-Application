Go
Create database MiniStore
GO

Use MiniStore
Go
-- Create Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

-- Create ProductTypes Table
CREATE TABLE ProductTypes (
    ProductTypeID INT PRIMARY KEY IDENTITY(1,1),
    ProductTypeName NVARCHAR(100) NOT NULL,
	CategoryID INT NOT NULL,
	FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

-- Create Products Table
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,         -- Mã sản phẩm (Tự động tăng)
    ProductName NVARCHAR(255) NOT NULL,              -- Tên sản phẩm
    ProductTypeID INT NOT NULL,                         -- Mã loại sản phẩm
    Brand NVARCHAR(255) NOT NULL,                    -- Thương hiệu
    CountryOfOrigin NVARCHAR(255) NULL,              -- Nơi sản xuất
    Price DECIMAL(18, 2) NOT NULL,                   -- Giá sản phẩm (số thập phân)
    StockQuantity INT NOT NULL,                      -- Số lượng tồn kho
    Unit NVARCHAR(50) NOT NULL,                      -- Đơn vị tính
    Description NVARCHAR(MAX) NULL,                  -- Mô tả sản phẩm
    Ingredients NVARCHAR(MAX) NULL,                  -- Thành phần
    Benefits NVARCHAR(MAX) NULL,                     -- Lợi ích
    Weight DECIMAL(10, 2) NULL,                      -- Khối lượng
    Flavor NVARCHAR(100) NULL,                       -- Hương vị
    ImageUrl NVARCHAR(255) NULL,                     -- Đường dẫn hình ảnh
    Status NVARCHAR(50) NULL,                        -- Trạng thái (ví dụ: Còn hạn lâu dài, Gần hết hạn, Hết hạn sử dụng, Hư hỏng)
    ManufactureDate DATE NOT NULL,                   -- Ngày sản xuất
    ExpirationDate DATE NOT NULL                     -- Ngày hết hạn
FOREIGN KEY (ProductTypeID) REFERENCES ProductTypes(ProductTypeID)
);


-- Create Suppliers Table
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(200)
);
--- Create table SupplierProducts
CREATE TABLE SupplierProducts (
    ProductId INT PRIMARY KEY IDENTITY,  -- Assuming ProductId is an auto-incrementing primary key
    ProductName NVARCHAR(255) NOT NULL,
    ProductTypeID INT NOT NULL,
    Brand NVARCHAR(100),
    CountryOfOrigin NVARCHAR(100),
    Price DECIMAL(18, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    Unit NVARCHAR(50),
    Description NVARCHAR(MAX),
    Ingredients NVARCHAR(MAX),
    Benefits NVARCHAR(MAX),
    Weight DECIMAL(10, 2),
    Flavor NVARCHAR(100),
    ManufactureDate DATE NOT NULL,
    ExpirationDate DATE NOT NULL,
    ImageUrl NVARCHAR(500),
    Status NVARCHAR(50),
    SupplierID INT NOT NULL,
    
    -- Optional: Add foreign key constraints if applicable
    CONSTRAINT FK_ProductType FOREIGN KEY (ProductTypeID) REFERENCES ProductTypes(ProductTypeID),
    CONSTRAINT FK_Supplier FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);

-- Create Employees Table
CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    Img NVARCHAR(255),
    Name NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(15),
    Gender NVARCHAR(10),
    DayOfBirth DATE
);



-- Create Customers Table
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    RewardPoint INT DEFAULT 0,
    Name NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(15),
    Gender NVARCHAR(10),
    DayOfBirth DATE
); 


-- Create Promotions Table
CREATE TABLE Promotions (
    PromotionID INT PRIMARY KEY ,
	ProductID INT NULL,
    PromotionName NVARCHAR(150) NOT NULL,
	Point INT DEFAULT 0,
	DiscountPercent DECIMAL(5, 2) NOT NULL, 
    StartDate  DATE DEFAULT GETDATE(),
    EndDate DATE NOT NULL,
	IsActive BIT DEFAULT ((1)) NOT NULL,
);

-- Create PromotionDetails Table
CREATE TABLE CustomerPromotions  (
    PromotionID  INT NOT NULL,
    CustomerID  INT NOT NULL,
    ReceivedDate DATE DEFAULT GETDATE(),
	IsUsed BIT DEFAULT((0)),
    PRIMARY KEY (PromotionID, CustomerID),
    FOREIGN KEY (PromotionID) REFERENCES Promotions(PromotionID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

-- Create PurchaseInvoices Table
CREATE TABLE PurchaseInvoices (
    PurchaseInvoiceID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT NOT NULL,
    EmployeeID INT NOT NULL,
    PurchaseDate  DATE DEFAULT GETDATE(),
    TotalAmount DECIMAL(15, 2) NOT NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- Create PurchaseInvoiceDetails Table
CREATE TABLE PurchaseInvoiceDetails (
    PurchaseInvoiceID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(15, 2) NOT NULL,
    PRIMARY KEY (PurchaseInvoiceID, ProductID),
    FOREIGN KEY (PurchaseInvoiceID) REFERENCES PurchaseInvoices(PurchaseInvoiceID),
    FOREIGN KEY (ProductID) REFERENCES SupplierProducts(ProductID)
);

-- Tạo bảng Invoices
CREATE TABLE Invoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT NOT NULL,
    CustomerID INT NOT NULL,
    InvoiceDate DATE DEFAULT GETDATE(),
    TotalAmount DECIMAL(15, 2) NOT NULL,
    PointEarned INT DEFAULT 0,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- Tạo bảng InvoiceDetails
CREATE TABLE InvoiceDetails (
    InvoiceID INT NOT NULL,
    ProductID INT NOT NULL,
    PromotionID INT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(15, 2) NOT NULL,
    PRIMARY KEY (InvoiceID, ProductID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
    FOREIGN KEY (PromotionID) REFERENCES Promotions(PromotionID)
);







-----------------------------------INSERT INTO Categories
INSERT INTO Categories (CategoryName)
VALUES
(N'Thịt, Cá, Trứng, Hải Sản'),
(N'Rau, Củ, Nấm, Trái Cây'),
(N'Dầu Ăn, Nước Chấm, Gia Vị'),
(N'Mì, Miến, Cháo, Phở'),
(N'Kem, Thực Phẩm Đông Mát'),
(N'Gạo, Bột, Đồ Khô'),
(N'Bia, Nước Giải Khát'),
(N'Sữa Các Loại'),
(N'Bánh Kẹo Các Loại'),
(N'Khác');

--------------------------------INSERT INTO ProductTypes

INSERT INTO ProductTypes (ProductTypeName, CategoryID)
VALUES
-- Thịt, Cá, Trứng, Hải Sản
(N'Thịt heo', 1),
(N'Thịt bò', 1),
(N'Thịt gà, vịt, chim', 1),
(N'Thịt sơ chế', 1),
(N'Cá, hải sản', 1),
(N'Trứng gà, vịt, cút', 1),

-- Rau, Củ, Nấm, Trái Cây
(N'Trái cây', 2),
(N'Rau lá', 2),
(N'Củ, quả', 2),
(N'Nấm các loại', 2),
(N'Rau, củ làm sẵn', 2),
(N'Hoa tươi', 2),
(N'Rau củ đông lạnh', 2),

-- Dầu Ăn, Nước Chấm, Gia Vị
(N'Dầu ăn', 3),
(N'Nước mắm', 3),
(N'Nước tương', 3),
(N'Đường', 3),
(N'Hạt nêm, bột ngọt, bột canh', 3),
(N'Muối', 3),
(N'Tương ớt - đen, mayonnaise', 3),
(N'Dầu hào, giấm, bơ', 3),
(N'Gia vị nêm sẵn', 3),
(N'Nước chấm, mắm', 3),
(N'Tiêu, sa tế, ớt bột', 3),
(N'Bột nghệ, tỏi, hồi, quế,...', 3),

-- Mì, Miến, Cháo, Phở
(N'Mì ăn liền', 4),
(N'Hủ tiếu, miến', 4),
(N'Phở, bún ăn liền', 4),
(N'Cháo gói, cháo tươi', 4),
(N'Bún các loại', 4),
(N'Nui các loại', 4),
(N'Miến, hủ tiếu, phở', 4),
(N'Mì Ý, mì trứng', 4),
(N'Bánh gạo Hàn Quốc', 4),

-- Kem, Thực Phẩm Đông Mát
(N'Bánh bao, bánh mì, pizza', 5),
(N'Xúc xích, lạp xưởng tươi', 5),
(N'Chả lụa, thịt nguội', 5),
(N'Chả giò, chả ram', 5),
(N'Cá viên, bò viên', 5),
(N'Mandu, há cảo, sủi cảo', 5),
(N'Thịt, cá đông lạnh', 5),
(N'Làm sẵn, ăn liền', 5),
(N'Sơ chế, tẩm ướp', 5),
(N'Nước lẩu, viên thả lẩu', 5),
(N'Sữa chua ăn', 5),
(N'Bơ sữa, phô mai', 5),
(N'Sữa chua uống', 5),
(N'Đậu hũ, tàu hũ', 5),
(N'Kim chi, đồ chua', 5),
(N'Bánh flan, thạch, chè', 5),

-- Gạo, Bột, Đồ Khô
(N'Gạo các loại', 6),
(N'Xúc xích', 6),
(N'Cá hộp', 6),
(N'Đồ chay ăn liền', 6),
(N'Heo, bò, pate hộp', 6),
(N'Tương, chao các loại', 6),
(N'Gia vị chay', 6),
(N'Đậu hũ, đồ chay khác', 6),
(N'Bột các loại', 6),
(N'Đậu, nấm, đồ khô', 6),
(N'Rong biển các loại', 6),
(N'Lạp xưởng', 6),
(N'Cá mắm, dưa mắm', 6),
(N'Bánh phồng, bánh đa', 6),
(N'Bánh tráng các loại', 6),
(N'Nước cốt dừa lon', 6),
(N'Rau củ, trái cây hộp', 6),
(N'Ngũ cốc, yến mạch', 6),

-- Bia, Nước Giải Khát
(N'Bia, nước có cồn', 7),
(N'Rượu', 7),
(N'Nước ép trái cây', 7),
(N'Nước tăng lực, bù khoáng', 7),
(N'Nước ngọt', 7),
(N'Nước trà', 7),
(N'Sữa trái cây, trà sữa', 7),
(N'Trái cây hộp, siro', 7),
(N'Nước suối', 7),
(N'Cà phê hòa tan', 7),
(N'Trà khô, túi lọc', 7),
(N'Cà phê pha phin', 7),
(N'Cà phê lon', 7),
(N'Mật ong, bột nghệ', 7),
(N'Nước yến, nước cốt gà', 7),

-- Sữa Các Loại
(N'Sữa tươi', 8),
(N'Sữa ca cao, lúa mạch', 8),
(N'Sữa chua uống liền', 8),
(N'Sữa bột', 8),
(N'Sữa hạt, sữa đậu', 8),
(N'Sữa đặc', 8),
(N'Ngũ cốc', 8),
(N'Sữa chua ăn', 8),
(N'Bơ sữa, phô mai', 8),

-- Bánh Kẹo Các Loại
(N'Bánh quy', 9),
(N'Bánh gạo', 9),
(N'Bánh quế', 9),
(N'Bánh snack, rong biển', 9),
(N'Bánh Chocopie', 9),
(N'Bánh bông lan', 9),
(N'Bánh tươi, Sandwich', 9),
(N'Socola', 9),
(N'Bánh que', 9),
(N'Kẹo cứng', 9),
(N'Kẹo dẻo, kẹo marshmallow', 9),
(N'Kẹo singum', 9),
(N'Trái cây sấy', 9),
(N'Hạt khô', 9),
(N'Rau câu, thạch dừa', 9),
(N'Khô chế biến sẵn', 9),
(N'Mứt trái cây', 9),
(N'Cơm cháy, bánh tráng', 9),

-- Khác
(N'Khác', 10);

------------------------------------Products—-----------------------------------
-- Thịt, Cá, Trứng, Hải Sản
INSERT INTO Products (ProductName, ProductTypeID, Brand, CountryOfOrigin, Price, StockQuantity, Unit, ManufactureDate, ExpirationDate, Status)
VALUES
(N'Thịt heo', 1, N'ABC Brand', N'Việt Nam', 100000, 50, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Thịt bò', 1, N'XYZ Brand', N'Việt Nam', 150000, 30, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Thịt gà', 1, N'MNH Brand', N'Việt Nam', 120000, 70, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Thịt vịt', 1, N'Viet Meat', N'Việt Nam', 110000, 40, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Thịt chim', 1, N'Birds Co.', N'Việt Nam', 130000, 60, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Cá hồi', 1, N'Seafood Masters', N'Norway', 250000, 20, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Cá ngừ', 1, N'Fresh Fish', N'Việt Nam', 200000, 25, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Cá basa', 1, N'Fresh Water', N'Việt Nam', 80000, 100, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Cá mập', 1, N'FishCo', N'Việt Nam', 300000, 15, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Trứng gà', 1, N'Egg Masters', N'Việt Nam', 20000, 500, N'cái', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài')

-- Rau, Củ, Nấm, Trái Cây
INSERT INTO Products (ProductName, ProductTypeID, Brand, CountryOfOrigin, Price, StockQuantity, Unit, ManufactureDate, ExpirationDate, Status)
VALUES
(N'Trái cây', 2, N'Fruits Brand', N'Việt Nam', 30000, 200, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Rau lá', 2, N'Vegetable Co.', N'Việt Nam', 15000, 300, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Củ cải', 2, N'Organic Brand', N'Việt Nam', 20000, 250, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Rau cải', 2, N'Green Veg', N'Việt Nam', 18000, 200, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Nấm hương', 2, N'Mushroom Co.', N'Việt Nam', 50000, 100, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Nấm bào ngư', 2, N'Mushroom Farm', N'Việt Nam', 55000, 80, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Nấm linh chi', 2, N'Herb Co.', N'Việt Nam', 60000, 50, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Rau ngót', 2, N'Organic Co.', N'Việt Nam', 25000, 150, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Rau muống', 2, N'Vegetable Masters', N'Việt Nam', 12000, 180, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài'),
(N'Hoa quả', 2, N'Fruit Co.', N'Việt Nam', 40000, 120, N'kg', '2024-11-01', '2025-05-01', N'Còn hạn lâu dài')

-- Dầu Ăn, Nước Chấm, Gia Vị
INSERT INTO Products (ProductName, ProductTypeID, Brand, CountryOfOrigin, Price, StockQuantity, Unit, ManufactureDate, ExpirationDate, Status)
VALUES
(N'Dầu ăn', 3, N'Food Oil', N'Việt Nam', 50000, 200, N'lít', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Nước mắm', 3, N'Sea Food Co.', N'Việt Nam', 40000, 300, N'lít', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Nước tương', 3, N'Soy Co.', N'Việt Nam', 25000, 500, N'lít', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Đường', 3, N'Sugar Brand', N'Việt Nam', 30000, 100, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Hạt nêm', 3, N'Flavor Co.', N'Việt Nam', 35000, 200, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Bột ngọt', 3, N'Spice Co.', N'Việt Nam', 27000, 180, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Gia vị nêm sẵn', 3, N'Cuisine Co.', N'Việt Nam', 30000, 150, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Muối', 3, N'Salt Co.', N'Việt Nam', 10000, 250, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Tương ớt', 3, N'Hot Sauce Co.', N'Việt Nam', 15000, 220, N'kg', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Dầu hào', 3, N'Asian Food', N'Việt Nam', 45000, 300, N'lít', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài')

-- Mì, Miến, Cháo, Phở
INSERT INTO Products (ProductName, ProductTypeID, Brand, CountryOfOrigin, Price, StockQuantity, Unit, ManufactureDate, ExpirationDate, Status)
VALUES
(N'Mì ăn liền', 4, N'Meal Co.', N'Việt Nam', 10000, 1000, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Hủ tiếu', 4, N'Meal Co.', N'Việt Nam', 15000, 800, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Phở ăn liền', 4, N'Quick Meals', N'Việt Nam', 12000, 600, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Miến', 4, N'Super Food', N'Việt Nam', 20000, 500, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Mì xào', 4, N'Yummy Foods', N'Việt Nam', 18000, 700, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Mì Hàn Quốc', 4, N'Korean Food', N'Hàn Quốc', 25000, 400, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Cháo', 4, N'Breakfast Brand', N'Việt Nam', 15000, 200, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Bánh canh', 4, N'Meal Co.', N'Việt Nam', 12000, 500, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Súp', 4, N'Healthy Meal', N'Việt Nam', 20000, 350, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài'),
(N'Mì trứng', 4, N'Quick Meals', N'Việt Nam', 13000, 900, N'bao', '2024-11-01', '2025-11-01', N'Còn hạn lâu dài')

------------------------------------CUSTOMERS—-----------------------------------
INSERT INTO Customers (Name, Phone, Gender, DayOfBirth)
VALUES
(N'Nguyễn Văn A', '0987654321', N'Nam', '1990-01-15'),
(N'Lê Thị B', '0912345678', N'Nữ', '1992-03-25'),
(N'Trần Văn C', '0978123456', N'Nam', '1985-07-10'),
(N'Phạm Thị D', '0908765432', N'Nữ', '1998-05-22'),
(N'Hoàng Văn E', '0932123456', N'Nam', '1978-12-02'),
(N'Nguyễn Thị F', '0943218765', N'Nữ', '1995-09-15'),
(N'Lê Văn G', '0965432876', N'Nam', '1982-04-18'),
(N'Trần Thị H', '0921564875', N'Nữ', '1990-08-30'),
(N'Phạm Văn I', '0912345678', N'Nam', '1987-02-14'),
(N'Hoàng Thị J', '0978561234', N'Nữ', '1993-11-25'),
(N'Lý Văn K', '0954328761', N'Nam', '1989-06-10'),
(N'Võ Thị L', '0939876543', N'Nữ', '1991-01-20'),
(N'Doãn Văn M', '0923456789', N'Nam', '1994-12-05'),
(N'Tạ Thị N', '0905432876', N'Nữ', '1996-10-22'),
(N'Hà Văn O', '0912348765', N'Nam', '1980-09-13'),
(N'Tôn Thị P', '0943215678', N'Nữ', '1992-02-11'),
(N'Bùi Văn Q', '0978654321', N'Nam', '1983-07-17'),
(N'Triệu Thị R', '0907654321', N'Nữ', '1988-08-19'),
(N'Dương Văn S', '0918765432', N'Nam', '1991-03-12'),
(N'Ngô Thị T', '0921345678', N'Nữ', '1995-05-15');
------------------------------------EMPLOYEES—-----------------------------------
INSERT INTO Employees (Email, Password, Role, Status, Img, Name, Phone, Gender, DayOfBirth)
VALUES
('admin1@gmail.com', 'password123', N'Admin', N'Đang làm việc', 'u2.png', N'Nguyễn Văn A', '0987123456', N'Nam', '1985-12-01'),
('sales1@gmail.com', 'password123', N'Nhân viên bán hàng', N'Đang làm việc', 'u2.png', N'Lê Thị B', '0912345678', N'Nữ', '1992-05-10'),
('sales2@gmail.com', 'password123', N'Nhân viên bán hàng', N'Đang làm việc', 'u2.png', N'Trần Văn C', '0321654987', N'Nam', '1994-09-15'),
('stock1@gmail.com', 'password123', N'Nhân viên nhập hàng', N'Đang làm việc', 'u4.png', N'Phạm Thị N', '0776541239', N'Nữ', '1993-07-20'),
('stock2@gmail.com', 'password123', N'Nhân viên nhập hàng', N'Đang làm việc', 'u4.png', N'Hoàng Văn K', '0909123456', N'Nam', '1990-11-25');


-- Insert dữ liệu vào bảng Suppliers
INSERT INTO [dbo].[Suppliers] (SupplierName, Phone, Email, Address)
VALUES
    (N'Trường Phát', N'0901234567', N'truongphat@example.com', N'123 Đường ABC, Quận 1, TP.HCM'),
    (N'Mai Linh', N'0912345678', N'mailinh@example.com', N'456 Đường XYZ, Quận 3, TP.HCM'),
    (N'Vạn Phúc', N'0923456789', N'vanphuc@example.com', N'789 Đường 123, Quận 5, TP.HCM'),
    (N'Hoàng Anh', N'0934567890', N'hoanganh@example.com', N'123 Đường 456, Quận 7, TP.HCM'),
    (N'Châu Âu', N'0945678901', N'chauau@example.com', N'234 Đường 789, Quận 10, TP.HCM'),
    (N'Hoàng Dương', N'0956789012', N'hoangduong@example.com', N'345 Đường 101, Quận 11, TP.HCM'),
    (N'Nhà Sản Xuất X', N'0967890123', N'nhasx@example.com', N'456 Đường 202, Quận 12, TP.HCM'),
    (N'Minh Tâm', N'0978901234', N'minhtam@example.com', N'567 Đường 303, Quận 9, TP.HCM'),
    (N'Vinh Hoa', N'0989012345', N'vinhhoa@example.com', N'678 Đường 404, Quận 8, TP.HCM'),
    (N'Phú Quý', N'0990123456', N'phuqui@example.com', N'789 Đường 505, Quận 6, TP.HCM');

-- Insert dữ liệu vào bảng SupplierProducts (mỗi nhà cung cấp sẽ cung cấp 10 sản phẩm thuộc các ProductTypeID khác nhau)
INSERT INTO [dbo].[SupplierProducts] (ProductName, ProductTypeID, Brand, CountryOfOrigin, Price, StockQuantity, Unit, Description, Ingredients, Benefits, Weight, Flavor, ManufactureDate, ExpirationDate, ImageUrl, Status, SupplierID)
VALUES
-- Nhà cung cấp: Trường Phát (SupplierID = 1)
(N'Thịt Heo Hảo Hạng', 1, N'Trường Phát', N'Việt Nam', 150000, 100, N'Kg', N'Những miếng thịt heo tươi ngon, được chọn lọc từ những con heo khỏe mạnh', N'Heo', N'Thịt heo giàu protein', 1.2, N'Không có', '2024-01-01', '2025-01-01', N'https://image1.com', N'Còn hạn lâu dài', 1),
(N'Thịt Bò Mỹ', 1, N'Vạn Phúc', N'Mỹ', 500000, 200, N'Kg', N'Thịt bò được nhập khẩu từ Mỹ, có chất lượng cao', N'Bò', N'Thịt bò giàu sắt', 1.5, N'Không có', '2023-12-01', '2024-12-01', N'https://image2.com', N'Còn hạn lâu dài', 1),
(N'Thịt Gà Free Range', 1, N'Mai Linh', N'Việt Nam', 120000, 150, N'Kg', N'Thịt gà nuôi tự nhiên, không hormone', N'Gà', N'Thịt gà giàu protein', 1.0, N'Không có', '2024-02-01', '2025-02-01', N'https://image3.com', N'Còn hạn lâu dài', 1),
(N'Cá Hồi', 1, N'Hoàng Dương', N'Na Uy', 350000, 80, N'Kg', N'Cá hồi nhập khẩu, giàu omega-3', N'Cá hồi', N'Cá hồi tốt cho tim mạch', 2.0, N'Không có', '2024-03-01', '2025-03-01', N'https://image4.com', N'Còn hạn lâu dài', 1),
(N'Chả Lụa', 1, N'Hoàng Anh', N'Việt Nam', 100000, 200, N'Kg', N'Chả lụa tươi ngon, chất lượng cao', N'Theo gia vị', N'Chả lụa là món ăn truyền thống', 1.3, N'Không có', '2024-04-01', '2025-04-01', N'https://image5.com', N'Còn hạn lâu dài', 1),
-- Nhà cung cấp: Mai Linh (SupplierID = 2)
(N'Trái Cây Tươi', 2, N'Mai Linh', N'Việt Nam', 200000, 300, N'Kg', N'Trái cây tươi ngon, đủ loại', N'Trái cây', N'Trái cây tốt cho sức khỏe', 0.8, N'Không có', '2024-01-01', '2025-01-01', N'https://image6.com', N'Còn hạn lâu dài', 2),
(N'Rau Củ Tươi', 2, N'Mai Linh', N'Việt Nam', 50000, 500, N'Kg', N'Rau củ tươi ngon, bảo vệ sức khỏe', N'Rau, Củ', N'Rau củ tốt cho hệ tiêu hóa', 0.3, N'Không có', '2024-01-01', '2025-01-01', N'https://image7.com', N'Còn hạn lâu dài', 2),
(N'Củ Cải', 2, N'Trường Phát', N'Việt Nam', 30000, 400, N'Kg', N'Củ cải tươi, chất lượng', N'Củ cải', N'Củ cải giàu vitamin', 0.5, N'Không có', '2024-01-01', '2025-01-01', N'https://image8.com', N'Còn hạn lâu dài', 2),
(N'Nấm Rơm', 2, N'Mai Linh', N'Việt Nam', 150000, 300, N'Kg', N'Nấm rơm tươi ngon, phù hợp với mọi món ăn', N'Nấm', N'Nấm tốt cho sức khỏe', 0.4, N'Không có', '2024-02-01', '2025-02-01', N'https://image9.com', N'Còn hạn lâu dài', 2),
(N'Hoa Tươi', 2, N'Vinh Hoa', N'Việt Nam', 200000, 100, N'Bó', N'Hoa tươi đẹp, tặng cho người thân yêu', N'Hoa', N'Hoa tươi thơm, đẹp', 0.2, N'Không có', '2024-01-01', '2025-01-01', N'https://image10.com', N'Còn hạn lâu dài', 2);


