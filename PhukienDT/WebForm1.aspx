<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PhukienDT.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang chủ</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <link href="Content/StyleSheet1.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!---
        <div>
            <img style="height:90px; margin-left:60px; margin-top:-10px" src="img\logo2.png"" />
        </div>
        <div style="margin-left: 220px; margin-top:-60px">
            <div style="float:left; font-weight:bold; font-family:VnUniverse; margin-left:50px; font-size:17px">
                <a href="#">TRANG CHỦ</a>
            </div>
            <div style="float:left; font-weight:bold; font-family:VnUniverse; margin-left:50px; font-size:17px">
                <a href="#">SẢN PHẨM</a>
            </div>
            <div style="float:left; font-weight:bold; font-family:VnUniverse; margin-left:50px; font-size:17px">
                <a href="#">THÔNG TIN</a>
            </div>
        </div>
        <div style="float:left;margin-left: 900px; margin-top:-35px">
            <input class="search" id="txtSearch1" type="text" placeholder="Search..." />
        </div>
        <div style="float:left;margin-top:-27px">
            <img style="height:25px; margin-left:-40px; margin-top:-3px" src="img\search.png" />
        </div>
        <div style="float:left;margin-top:-30px">
            <a href="#"><img style="height:27px; margin-left: 40px" src="img\heart.png" /></a>
            <a href="#"><img style="height:27px; margin-left: 20px" src="img\bag.png" /></a>
            <a href="#"><img style="height:27px; margin-left: 20px" src="img\login.png" /></a>
        </div>
        <br /><br /><br />
        --->

        <nav class="navbar">
          <div class="container-fluid">
            <div class="navbar-header">
              <a class="navbar-brand" href="#"><img style="height:90px; margin-left:60px; margin-top:-10px" src="img\logo2.png"" /></a>
            </div>
            <ul class="nav navbar-nav">
              <li class="active"><a href="#">Trang chủ</a></li>
              <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Sản phẩm <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">Ốp lưng</a></li>
                  <li><a href="#">Bao airpod</a></li>
                  <li><a href="#">Ring-Bóp</a></li>
                  <li><a href="#">Khác</a></li>
                </ul>
              </li>
              <li><a href="#">Thông tin</a></li>
            </ul>
              

              <div style="float:left;margin-left: 900px; margin-top:-35px">
            <input class="search" id="txtSearch" type="text" placeholder="Search..." />
        </div>
        <div style="float:left;margin-top:-27px">
            <img style="height:25px; margin-left:-40px; margin-top:5px" src="img\search.png" />
        </div>
        <div style="float:left;margin-top:-30px">
            <a href="#"><img style="height:27px; margin-left: 40px" src="img\heart.png" /></a>
            <a href="#"><img style="height:27px; margin-left: 20px" src="img\bag.png" /></a>
            <a onclick="document.getElementById('user').style.display='block'"><img style="height:27px; margin-left: 20px" src="img\login.png" /></a>
         
            <div id="user" class="modal">
  
              <form class="modal-content animate" action="/action_page.php">
                <div class="imgcontainer">
                  <span onclick="document.getElementById('user').style.display='none'" class="close" title="Close Modal">&times;</span>
                  <img style="width:25%; margin-top: -50px" src="img\logo3.png" alt="Avatar" class="avatar">
                </div>

                <div class="container">
                  <div style="margin-left: 225px">
                      <label for="uname"><b>Username</b></label>
                      <input type="text" placeholder="Enter Username" name="uname" required>
                  </div>

                  <div style="margin-left: 225px">
                      <label for="psw"><b>Password</b></label>
                      <input type="password" placeholder="Enter Password" name="psw" required>
                  </div>

                  <label style="margin-left: 225px">
                    <input type="checkbox" checked="checked" name="remember"> Remember me
                  </label>

                    <div>
                        <span class="psw"> <a href="#">Forgot password?</a></span>
                    </div>
        
                  <div>
                      <div style="margin-left: 400px"><button type="submit">Login</button></div>
                      <div style="margin-left: 600px; margin-top: -65px"><button type="submit">Register</button></div>
                  </div>
                </div>

                  <!---
                <div class="container">
                  <button type="button" onclick="document.getElementById('user').style.display='none'" class="cancelbtn">Cancel</button>
                  <span class="psw"> <a href="#">Forgot password?</a></span>
                </div>
                      --->
              </form>
            </div>

            <script>
            // Get the modal
            var modal = document.getElementById('user');

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function(event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }
            </script>
        </div>
          </div>
        </nav>
        <!---
        <div>
            <nav class="navbar navbar-inverse">
              <div class="container-fluid">
                <div class="navbar-header">
                  <a class="navbar-brand" href="#">
                      <img style="width:200px; height:50px; margin-top: -15px" src="img\logo1.png" />
                  </a>
                </div>
                <ul class="nav navbar-nav">
                  <li class="active"><a href="#">Home</a></li>
                  <li><a href="#">Page 1</a></li>
                  <li><a href="#">Page 2</a></li>
                  <li><a href="#">Page 3</a></li>

                    <li><a href="#">icon 1</a></li>
                    <li><a href="#">icon 2</a></li>
                    <li><a href="#">icon 3</a></li>
                </ul>
              </div>
            </nav>   
        </div>
        --->

        <!--- Hình --->
        <div class="slideshow-container">
        <div class="mySlides fade">
          <img src="img\nen1.png" style="margin-left:-450px; width:1374px; height:505px">
        </div>

        <div class="mySlides fade">
          <img src="img\nen2.png" style="margin-left:-450px; width:1374px; height:505px">
        </div>

        <div class="mySlides fade">
          <img src="img\nen3.png" style="margin-left:-450px; width:1374px; height:505px">
        </div>
      </div>
      <br>

      <div style="text-align:center">
        <span class="dot" onclick="currentSlide(0)"></span> 
        <span class="dot" onclick="currentSlide(1)"></span> 
        <span class="dot" onclick="currentSlide(2)"></span> 
      </div>  
    </body>
    <script>
      //khai báo biến slideIndex đại diện cho slide hiện tại
      var slideIndex;
      // KHai bào hàm hiển thị slide
      function showSlides() {
          var i;
          var slides = document.getElementsByClassName("mySlides");
          var dots = document.getElementsByClassName("dot");
          for (i = 0; i < slides.length; i++) {
             slides[i].style.display = "none";  
          }
          for (i = 0; i < dots.length; i++) {
              dots[i].className = dots[i].className.replace(" active", "");
          }

          slides[slideIndex].style.display = "block";  
          dots[slideIndex].className += " active";
          //chuyển đến slide tiếp theo
          slideIndex++;
          //nếu đang ở slide cuối cùng thì chuyển về slide đầu
          if (slideIndex > slides.length - 1) {
            slideIndex = 0
          }    
          //tự động chuyển đổi slide sau 5s
          setTimeout(showSlides, 3000);
      }
      //mặc định hiển thị slide đầu tiên 
      showSlides(slideIndex = 0);


      function currentSlide(n) {
        showSlides(slideIndex = n);
      }
    </script>

    <div style=" width:90%; margin-left:5%">
        <div>
            <!---<div><img style="width:130px; margin-left:240px" src="img\rabbit.png" /></div>
            <div style="text-align:center; margin-top: -150px ;font-family:'HP-Murray Heavy'; font-weight:bold; font-size:100px">Best Seller</div>
            <div><img style="width:130px; margin-left: 850px; margin-top: -150px" src="img\rabbit1.png" /></div>--->
        </div>
        <div style="text-align:center;font-family:'HP-Murray Heavy'; font-weight:bold; font-size:100px">Best Seller</div>

        <div style="margin-left: 5px">
            <div style="float:left">
            <a href="#">
                <img style="width:180px" src="img\44.png">
            </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:180px; margin-left: 20px" src="img\46.png">
                </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:180px; margin-top:200px; margin-left:-380px" src="img\20.png">
                </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:180px; margin-top:200px; margin-left:-180px" src="img\9.png">
                </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:380px; margin-left: 20px" src="img\14.png">
                </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:180px; margin-left: 20px" src="img\44.png">
                </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:180px; margin-left: 20px" src="img\46.png">
                </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:180px; margin-top:18px; margin-left: 20px" src="img\20.png">
                </a>
            </div>
            <div style="float:left">
                <a href="#">
                    <img style="width:180px; margin-top:18px; margin-left: 20px" src="img\9.png">
                </a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
