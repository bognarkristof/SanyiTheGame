<?php
$servername ="localhost";
$username="root";
$password="";
$dbname="sanyiz";

$conn = new mysqli($servername,$username,$password,$dbname);
$registUser=$_POST["registUser"];
$registPass=$_POST["registPass"];
$registEmail = $_POST["registEmail"];
$registFullname=$_POST["registFullname"];

$create_date = date("Y-m-d");

$userDataCoin = 0;
$userDataSteps = 0;
$userDataScoin = 0;


if($conn->connect_error){
    die("Connection failed: ".$conn->connection_error);
}
echo "Connected to database<br>";


$insertUser ="INSERT INTO user(username,password,email,create_date) VALUES('".$registUser."','".$registPass."','".$registEmail."','".$create_date."')";
$insertUserData = "INSERT INTO user_data(coin,steps,Scoin) VALUES('".$userDataCoin."','".$userDataSteps."','".$userDataScoin."')";
$insertPersonalInform="INSERT INTO personal_inform(fullname) VALUES('".$registFullname."')";



$result ="SELECT username FROM user WHERE username = '".$registUser."'";

if($result->num_rows != 0){
    echo "Username already taken";
    
        
} else{
    echo "Creating user...";
    $resultUser = $conn->query($insertUser);
    $resultData = $conn->query($insertUserData);
    $resultPersonal = $conn->query($insertPersonalInform);

    echo "Successfull register";
}

$conn->close();


?>