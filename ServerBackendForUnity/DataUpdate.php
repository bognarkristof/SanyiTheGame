<?php
define("DB_HOST","localhost");
define("DB_USER","id18591325_admin");
define("DB_PASS","M_g$6PH447TtbSOl");
define('DB_DATABASE','id18591325_sanyiz');

$conn = mysqli_connect(DB_HOST,DB_USER,DB_PASS,DB_DATABASE);
if(! $conn){
        die("Connection failed: ".mysqli_connect_error());
}

//submited variables
$Id = $_POST["id"];
$coins = $_POST["coins"];
$scoins = $_POST["scoins"];
$score = $_POST["score"];


$sql ="UPDATE user_data SET coin='$coins', score='$score',scoin='$scoins' WHERE user_id='$Id'";
$result = $conn->query($sql);

if($result){
    echo "succesfull update";
}else{
    echo "error";
}


$conn->close()



?>