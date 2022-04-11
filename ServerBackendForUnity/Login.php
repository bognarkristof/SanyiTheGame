<?php
$servername ="localhost";
$username="root";
$password="";
$dbname="sanyiz";

//submited variables
$loginUser =$_POST["loginUser"];
$loginPass =$_POST["loginPass"];

//server connection
$conn = new mysqli($servername,$username,$password,$dbname);

if($conn->connect_error){
    die("Connection failed: ".$conn->connection_error);
}



$sql ="SELECT password FROM user WHERE username = '$loginUser'";
$result = $conn->query($sql);

if($result->num_rows>0){
    while($row = $result->fetch_assoc()){
        if($row["password"] == $loginPass){
            
            //Get player data(coin, Scoin, steps)
            $userData = "SELECT steps, scoin, coin, id FROM user_data WHERE id = (SELECT id FROM user WHERE username = '$loginUser')";
            $getUserData = $conn->query($userData);

            if(mysqli_num_rows($getUserData) > 0){
                while($row = mysqli_fetch_assoc($getUserData)){
                    echo "Steps:".$row['steps']."|SanyiCoin:".$row['scoin']."|Coins:".$row['coin']."|ID:".$row['id']. ";";
                }
            }
            

        }
        else{
            echo "wrong password or username";
        }
    }
} else{
    echo "no users found";
}

$conn->close();

?>



