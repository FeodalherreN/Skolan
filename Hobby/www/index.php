<!DOCTYPE html>
<html>

<head>
  <meta charset="UTF-8">
  <title>Login</title>
    <link rel="stylesheet" href="css/style.css" media="screen" type="text/css" />
</head>
<body>
  <html lang="en-US">
<head>
	<meta charset="utf-8">
	<title>Login</title>
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400,700">
</head>
<body>
    <div id="login">
        <form action="/controller/login.php" method="POST">
            <fieldset class="clearfix">
                <p><span class="fontawesome-user"></span><input type="text" id="un" name="un" value="Username" onBlur="if(this.value == '') this.value = 'Username'" onFocus="if(this.value == 'Username') this.value = ''" required></p> <!-- JS because of IE support; better: placeholder="Username" -->
                <p><span class="fontawesome-lock"></span><input type="password" id="pw" name ="pw" value="Password" onBlur="if(this.value == '') this.value = 'Password'" onFocus="if(this.value == 'Password') this.value = ''" required></p> <!-- JS because of IE support; better: placeholder="Password" -->
                <p><input type="submit" value="Sign In"></p>
            </fieldset>
        </form>
    </div> <!-- end login -->
</body>
</html>
</body>
</html>