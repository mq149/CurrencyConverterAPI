#  CurrencyConverter

Phát triển Ứng dụng Hệ thống thông tin hiện đại - Lab#3: Bài tập ASP.NET Core tạo API.

  

##  Yêu cầu bài tập:

Sinh viên hãy thực hiện lại bài hướng dẫn trên để hiểu cách hoạt động hệ thống, ứng dụng  
xây dựng Web API và sử dụng nó. 
Yêu cầu: Sinh viên xây dựng một trang web đơn giản để tính toán việc chuyển đổi tiền tệ  
từ $ sang VNĐ bằng cách sử dụng Web API. 
Hai tham số cần cung cấp là số tiền cần đổi, tỉ giá $, kết quả trả về tiền VNĐ.

##  Kết quả
  
API chạy ở ```localhost:44314```
WebApp chạy ở ```localhost: 44363```, Trang chuyển đổi tiền tệ: ```/Converter```

###  CurrencyConverterAPI.Controller: ```ConverterController.cs```
```
[Route("api/[controller]")]
public class ConverterController : Controller
{
	// GET: api/Converter
	[HttpGet("convert/{amount}/{exchangeRate}")]
	public float convert(float amount, float exchangeRate)
	{
		CurrencyConverterAPI.Models.Converter converter = new Models.Converter(amount, exchangeRate);
		converter.convert();
		return converter.result;
	}
}
```

###  CurrencyConverterAPI.Models: ```Converter.cs```

Định nghĩa các thuộc tính và phương thức của model chuyển đổi tiền tệ.
```
public class Converter
{
	public float amount;
	public float exchangeRate;
	public float result;
	
	public Converter(float amount, float exchangeRate)
	{
		this.amount = amount;
		this.exchangeRate = exchangeRate;
	}
	
	public void convert()
	{
		result = amount * exchangeRate;
	}
}
```

| Tên | Loại | Kiểu dữ liệu/trả về | Mô tả |

|-------------------|----------------------|---------------------|--------------------------------------------------------------------|

| ```amount``` | thuộc tính | float | Giá trị tiền (USD) cần quy đổi |

| ```exchangeRate```| thuộc tính | float | Tỉ giá quy đổi |

| ```result``` | thuộc tính | float | Kết quả quy đổi |

| ```Converter``` | phương thức khởi tạo | | Khởi tạo amount và exchangeRate |

| ```convert``` | phương thức | void | Quy đổi dựa trên amount và exchangeRate và lưu kết quả vào result. |

  

###  CurrencyConverter.Page: ```Pages/Converter.cshtml```

Các thành phần chính trong view:

| Loại | ID(#)/Class(.)/Type | Mô tả |

|------------|------------------------------------------|-----------------------------------------------|

|```input``` | ```[type=text]```  ```#amount``` | Nhập giá trị cần quy đổi |

|```input``` | ```[type=text]```  ```#exchange-rate``` | Nhập tỷ giá quy đổi |

|```button```| ```#convert``` | Nhấp để thực hiện quy đổi tiền (AJAX) |

|```label``` | ```.result``` | Hiển thị kết quả quy đổi |

  
Page có sử dụng script ```converter.js``` (jQuery).

### Xử lý Access-Control-Allow-Origin
CORS là một cơ chế trong trình duyệt có từ Netscape Navigator 2 (1995) gọi là Same Origin Policy, để hạn chế một document hay một script tương tác với tài nguyên không cùng một gốc hay origin.
Cơ chế này nhằm hạn chế các cuộc tấn công Cross-site scripting (XSS), khi attacker nhúng cấy một đoạn mã vào các websites để gửi các thông tin đánh cắp được về máy chủ khác hoặc, thực hiện giao dịch bằng thông tin vừa ăn cắp được.

Cách xử lý: truy cập file ```Startup.cs``` của project ```CurrencyConverterAPI```:
Bước 1: Thêm dòng ``` services.AddCors();``` ngay dưới tên hàm ```ConfigureServices```.
Bước 2: Tiếp theo thêm đoạn code
```
app.UseCors(builder =>  builder
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());
```
trước đoạn ```app.UseHttpsRedirection();``` trong hàm ```Configure```.