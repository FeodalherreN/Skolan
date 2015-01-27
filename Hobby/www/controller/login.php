<?php
session_start();
$un = $_POST['un'];
$pw = $_POST['pw'];
if(isset($_POST['un']) && isset($_POST['pw']) && $un == "markus" && $pw == "m123")
{
	header('Location: /view/startpage.php');
}
else
{
	header('Location: /index.php');
}
?>