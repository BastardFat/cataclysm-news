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
const EOL = "<br>";

$data = json_decode(file_get_contents('php://input'), true);
print_r($data);



$link = mysqli_connect('sql303.byetcluster.com', 'rfgd_19686037', 't367830t', 'rfgd_19686037_news');

$title = mysqli_real_escape_string($link, $data["title"]);
$username = mysqli_real_escape_string($link, $data["username"]);
$avatar_url = mysqli_real_escape_string($link, $data["avatar_url"]);
$type = mysqli_real_escape_string($link, $data["type"]);
$label = mysqli_real_escape_string($link, $data["label"]);
$html = mysqli_real_escape_string($link, $data["html"]);

if (!$link) {
    echo "Error: Can't connect with MySQL." . EOL;
    echo "errno: " . mysqli_connect_errno() . EOL;
    echo "error: " . mysqli_connect_error() . EOL;
    exit;
}

echo "Connect with MySQL successed!" . EOL;
echo "Server information: " . mysqli_get_host_info($link) . EOL;

$query =
    "INSERT INTO rfgd_19686037_news.`news` (  title,    username,    avatar_url,    type,    label,    html,    `datetime`)
                                    VALUES ( '$title', '$username', '$avatar_url', '$type', '$label', '$html',  NOW()     );";

if ($stmt = mysqli_prepare($link, $query)) {

    mysqli_stmt_execute($stmt);
    echo "rows inserted: " . mysqli_stmt_affected_rows($stmt);
    mysqli_stmt_close($stmt);
}

mysqli_close($link);

?>