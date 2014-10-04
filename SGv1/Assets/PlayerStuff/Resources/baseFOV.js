private var baseFOV : float;
 
function Start () {
    baseFOV = Camera.main.fieldOfView;
}

	
    
    
function Update () {
    if (Input.GetMouseButton(1) || Input.GetKey ("joystick 1 button 4"))
     
        Camera.main.fieldOfView = 10;
        
    
    else 
        Camera.main.fieldOfView = baseFOV;

}