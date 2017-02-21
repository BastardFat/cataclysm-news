<?php
require_once("include-css.php");
require_once("include-js.php");
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Cataclysm News</title>
    <link href="./css/bootstrap-theme.css" rel="stylesheet" />
    <link href="./css/bootstrap.css" rel="stylesheet" />
    <style>
        .shadow {
            box-shadow: 1px 1px 3px 1px rgba(0,0,0,0.24);
        }

        .message {
            padding-top: 30px;
            padding-bottom: 30px;
            padding-right: 5%;
            padding-left: 5%;
            margin-bottom: 30px;
            color: inherit;
            background-color: #eee;
        }

            .message hr {
                border-top-color: #d5d5d5;
                margin: 0 !important;
            }

        body {
            padding-top: 50px;
            padding-bottom: 20px;
        }

        .body-content {
            padding-left: 15px;
            padding-right: 15px;
        }

        .btn {
            border-radius: 0px;
            box-shadow: 1px 1px 3px 1px rgba(0,0,0,0.24);
        }

        pre {
            border-radius: 0px;
        }

        .label {
            border-radius: 0px;
        }
    </style>

</head>
<body>
    <script src="/js/jquery-3.1.1.js"></script>
    <script src="/js/bootstrap.js"></script>
    <div class="container body-content">
        <?php include "view.php"; ?>

        <hr />
            <p>
                &copy; 2017 -
                <a href="https://github.com/BastardFat">BastardFat</a>
            </p>
    </div>

</body>
</html>
