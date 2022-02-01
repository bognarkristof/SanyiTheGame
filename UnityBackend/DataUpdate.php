<?php
$servername ="localhost";
$username="root";
$password="";
$dbname="sanyiz";

//submited variables
$id = $_POST["id"];
$coins = $_POST["coins"];
$scoins = $_POST["scoins"];
$steps = $_POST["steps"];

//server connection
$conn = new mysqli($servername,$username,$password,$dbname);

if($conn->connect_error){
    die("Connection failed: ".$conn->connection_error);
}


//$sql ="UPDATE user_data SET coin='$coins', steps='$steps',scoin='$scoins' WHERE id=(SELECT id FROM user WHERE username ='$user')";

$sql ="UPDATE user_data SET coin='$coins', steps='$steps',scoin='$scoins' WHERE id='$id'";
$result = $conn->query($sql);

if($result){
    echo "succesfull update";
}else{
    echo "error";
}


$conn->close()



?>