import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { NgForm,ValidatorFn,FormGroup,ValidationErrors,FormBuilder,Validators,FormControl, Form } from '@angular/forms';
import { IUser } from 'src/app/Interfaces/IUser';
import { OnlineBookService } from 'src/app/services/online-book.service'

const passwordErrorValidator:ValidatorFn=(control:FormGroup):ValidationErrors|null=>{
  const p=control.get('password');
  const c=control.get('confirmPassword');
  return p.value!=c.value && c.value!=null && c.value!=''?{'pwdError':true}:null;
};

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  user:IUser;
  registerForm:FormGroup;
  msg:string;
  pwd:string;

  constructor(private formBuilder:FormBuilder,private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
    this.registerForm=this.formBuilder.group({
      firstName:['',[Validators.required,Validators.pattern('[a-zA-Z]{1,}')]],
      lastName:['',[Validators.required,Validators.pattern('[a-zA-Z]{1,}')]],
      emailId:['',[Validators.required,Validators.pattern('[a-zA-Z0-9.]+@[a-zA-Z]+[.](com|COM)')]],
      gender:['',Validators.required],
      password:['',[Validators.required,Validators.pattern('.{8,16}')]],
      confirmPassword:['',[Validators.required]],
      contactNumber:['',[Validators.required,Validators.pattern('[1-9]{1}[0-9]{9}')]],
      dateOfbirth:['',[Validators.required,checkDate]],
      address:['',Validators.required]
    },{validators:passwordErrorValidator}
    );
  }

  SubmitForm(form:FormGroup){
    var a:number=Number(form.value.contactNumber)
    this.user={
      firstName:form.value.firstName,
      lastName:form.value.lastName,
      emailId:form.value.emailId,
      userPassword:form.value.password,
      address:form.value.address,
      gender:form.value.gender,
      dob:form.value.dateOfbirth,
      contactNo:Number(form.value.contactNumber)
    }
    this._onlineBookService.addUserDetails(this.user).subscribe(
      responseData=>{
        if(responseData==1){
          alert("Registered successfully.You can login now!!")
          this.router.navigate(['/userLogin'])
        }
        else{
          alert("Something went wrong.Please try again")
          window.location.reload();
          this.router.navigate(['/register'])
        }
      },
      responseError=>{
        alert("Something went wrong.Please try again.")
      },
      ()=>console.log("add User details executed successfully")
    )
    if(this.registerForm.valid){
      this.msg="SignUp Successful"
    }
    else{
      this.msg="Try again later"
    }
  }
}
function checkDate(control:FormControl){
  var currentDate=new Date();
  currentDate.setDate(currentDate.getDate()-1);
  var givenDate=new Date(control.value);
  if(givenDate<currentDate||givenDate==null){
    return null;
  }
  else{
    return{
      dateError:{
        message:"Enter a date less than today's date"
      }
    };
  }
}
