<?php

function CountPosts()
{
    $link = mysqli_connect('sql303.byetcluster.com', 'rfgd_19686037', 't367830t', 'rfgd_19686037_news');
    if (!$link) {
        echo "Error: Can't connect with MySQL." . EOL;
        echo "errno: " . mysqli_connect_errno() . EOL;
        echo "error: " . mysqli_connect_error() . EOL;
        exit;
    }

    $count = 0;

    $query = "SELECT COUNT(*) FROM rfgd_19686037_news.`news`;";

    if ($stmt = mysqli_prepare($link, $query)) {
        mysqli_stmt_execute($stmt);
        mysqli_stmt_bind_result($stmt, $count);
        mysqli_stmt_fetch($stmt);
        mysqli_stmt_close($stmt);
    }

    mysqli_close($link);
    return $count;
}


function GetPosts($offset)
{
    $link = mysqli_connect('sql303.byetcluster.com', 'rfgd_19686037', 't367830t', 'rfgd_19686037_news');
    if (!$link) {
        echo "Error: Can't connect with MySQL." . EOL;
        echo "errno: " . mysqli_connect_errno() . EOL;
        echo "error: " . mysqli_connect_error() . EOL;
        exit;
    }



    $query = "SELECT
                        title, username, avatar_url, type, label, html, `datetime`
            FROM        rfgd_19686037_news.`news`
            ORDER BY    `datetime` DESC
            LIMIT       10 OFFSET $offset ;";

    $result_list = array();

    if ($stmt = mysqli_prepare($link, $query)) {

        mysqli_stmt_execute($stmt);

        mysqli_stmt_bind_result($stmt, $title, $username, $avatar_url, $type, $label, $html, $datetime);

        while (mysqli_stmt_fetch($stmt)) {
            $result_list[] = array
            (
                "title" => $title,
                "username" => $username,
                "avatar_url" => $avatar_url,
                "type" => $type,
                "label" => $label,
                "html" => $html,
                "datetime" => $datetime
            );
        }

        mysqli_stmt_close($stmt);
    }

    mysqli_close($link);
    return $result_list;
}



?>