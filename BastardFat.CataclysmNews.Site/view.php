<?php require_once("./controller/index.php");
$notcanNext =  (intval((CountPosts()+9) / 10) - 1) < (intval($_GET['page']) + 1);
$notcanPrev =  (intval($_GET['page']) - 1) < 0

?>

<div class="navbar navbar-inverse navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a href="/" class="navbar-brand">Cataclysm DDA News</a>
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
                <li class="<?php if($notcanPrev) echo "disabled"; ?>">
                    <a href="<?php if($notcanPrev) echo "#"; else echo "/?page=".(intval($_GET['page']) - 1); ?>">Previous page</a>
                </li>
                <li class="<?php if($notcanNext) echo "disabled"; ?>">
                    <a href="<?php if($notcanNext) echo "#"; else echo "/?page=".(intval($_GET['page']) + 1); ?>">Next page</a>
                </li>
            </ul>
        </div>
    </div>
</div>

<h3>
    <span class="label label-default">Page <?php echo (intval($_GET['page']) + 1); ?></span>
    </h3>



    <?php
      $offset = intval($_GET['page']) * 10;
      $MODEL = GetPosts($offset);
      $i=0;
      foreach ($MODEL as $post)
      {
          $i++;
          $class = "default";
          if($post["label"] == "opened") $class = "danger";
          if($post["label"] == "reopened") $class = "warning";
          if($post["label"] == "closed") $class = "success";

          $typeclass = "primary";
          if ($post["type"] == "Pull Request") $typeclass = "success";
          if ($post["type"] == "Issue") $typeclass = "warning";


?>

    <div class="shadow message">
        <span style="color:darkgrey">
            <?php echo $post["datetime"]; ?>
            <small>CleverRaven - Cataclysm DDA News</small>
        </span>
        <hr />
        <ul class="list-inline">
            <li class="list-inline-item" style="vertical-align:top;">
                <h4><?php echo $post["username"]; ?></h4>
                <img src="<?php echo $post["avatar_url"]; ?>" class="img-thumbnail" alt="Avatar" width="100" height="100" />
                <h3>
                    <span class="label label-<?php echo $typeclass; ?>"><?php echo $post["type"]; ?></span>
                </h3>
                <h4>
                    <span class="label label-<?php echo $class; ?>"><?php echo $post["label"]; ?></span>
                </h4>
            </li>
            <li class="list-inline-item" style="width: 80%;">
                <h2 style="word-wrap:break-word;">
                    <?php echo $post["title"]; ?>
                </h2>
                <?php
 if( !empty($post["html"]) )
                             {
                ?>
                <button type="button" class="btn" data-toggle="collapse" data-target="#text_<?php echo $i; ?>">Read more...</button>

                <div id="text_<?php echo $i; ?>" class="collapse" style="padding-top:10px;word-wrap:break-word;">
                    <?php echo $post["html"];?>
                </div>
                <?php
                             }
                ?>
            </li>
        </ul>
    </div>
    <?php
      }
    ?>

<?php if(!$notcanNext) { ?>
<button type="button" style="align-self:center" onclick="location.href='<?php echo "/?page=".(intval($_GET['page']) + 1); ?>'" class="btn">Next page</button>
<?php } ?>
