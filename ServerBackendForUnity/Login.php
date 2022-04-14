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
$loginUser =$_POST["loginUser"];
$loginPass =$_POST["loginPass"];


$sql ="SELECT * FROM user WHERE username = '$loginUser'";
$result = $conn->query($sql);

if($result->num_rows>0){
    while($row = $result->fetch_assoc()){
        if($row["password"] == md5($loginPass)){
            //Get player data(coin, Scoin, score)
            $userData = "SELECT score, scoin, coin, id FROM user_data WHERE user_id = (SELECT id FROM user WHERE username = '$loginUser')";
            $getUserData = $conn->query($userData);
            
            if(mysqli_num_rows($getUserData) > 0){
                while($row = mysqli_fetch_assoc($getUserData)){
                    echo "Score:".$row['score']."|SanyiCoin:".$row['scoin']."|Coins:".$row['coin']."|ID:".$row['id']. ";";
                }
            }
            
            
        }
        else{
            echo "0";
            
        }
    }
} else{
    echo "1";
    
}

$conn->close();

?>



