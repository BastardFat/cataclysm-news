<?php
$allowed_IP = array(
	"80.80.101.176",
);
echo $_SERVER['REMOTE_ADDR'] . "<br>";

if(!in_array($_SERVER['REMOTE_ADDR'], $allowed_IP))
{
    header("HTTP/1.1 401 Unauthorized");
    die("Access denied!");
}

