<?php
define("DB_HOST","localhost");
define("DB_USER","id18591325_admin");
define("DB_PASS","M_g$6PH447TtbSOl");
define('DB_DATABASE','id18591325_sanyiz');

$conn = mysqli_connect(DB_HOST,DB_USER,DB_PASS,DB_DATABASE);
if(! $conn){
        die("Connection failed: ".mysqli_connect_error());
}
$registUser=$_POST["registUser"];
$registPass=$_POST["registPass"];
$registEmail = $_POST["registEmail"];
$registFullname=$_POST["registFullname"];
$userAge=$_POST["registAge"];
$create_date = date("Y-m-d");

$userDataCoin = 10;
$userDataScore = 10;
$userDataScoin = 10;


$insertUser ="INSERT INTO user(username,password,email,create_date) VALUES('".$registUser."','".md5($registPass)."','".$registEmail."','".$create_date."')";




$sql ="SELECT username FROM user WHERE username = '".$registUser."'";
$result = $conn->query($sql);
if($result->num_rows > 0){
    echo "0";
    die;
        
} else{
    
    $resultUser = $conn->query($insertUser);
    
    $userid = "SELECT id FROM user WHERE username = '".$registUser."'";
    
    $resultUserId = $conn->query($userid);
    if($resultUserId->num_rows> 0){
        while($row = mysqli_fetch_assoc($resultUserId)){
            $sanyi = $row["id"];
        }
		
        $insertUserData = "INSERT INTO user_data(coin,score,Scoin,user_id) VALUES('".$userDataCoin."','".$userDataScore."','".$userDataScoin."','".$sanyi."')";
        $insertPersonalInform="INSERT INTO personal_inform(fullname, age,user_id) VALUES('".$registFullname."','".$userAge."','".$sanyi."')";
        
        $resultData = $conn->query($insertUserData);
        $resultPersonal = $conn->query($insertPersonalInform);

        echo "1";
    }else{
        echo "2";
    }
    
}

$conn->close();


?>