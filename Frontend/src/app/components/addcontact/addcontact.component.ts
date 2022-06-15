import { Component, OnInit } from '@angular/core';
import { DirectBoss } from 'src/app/_models/manager';
import { ContactService } from 'src/app/_sevices/contact.service';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule, FormControl  } from '@angular/forms';
import { Contact } from 'src/app/_models/contact';
import { Router } from '@angular/router';







@Component({
  selector: 'app-addcontact',
  templateUrl: './addcontact.component.html',
  styleUrls: ['./addcontact.component.css']
})
export class AddcontactComponent implements OnInit {

  selectedGender : number =0;
  members = [] as Array<DirectBoss>;
  errorDivName: boolean = true;
  errorDivLName: boolean = true;
  errorDivPhone: boolean = true;

  newContact = {} as Contact;
  selectedTeamMember : number = 0;
  

  
  constructor(private service: ContactService,
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {

    this.newContact.phoneNumber = "";
    this.loadTeamMmbers();
  }

  loadTeamMmbers() {


    this.service.getAllTeamMembersList()
      .subscribe(data => {

        this.members = data;
        console.log(data);

      }
      );

  }
  onSubmit(form: any) {

        
    this.newContact.id =0;
    console.log(this.newContact);
    this.service.addNewContact(this.newContact).subscribe(res => {
        
    });

   this.router.navigateByUrl("/");
   


  }
    setSelectedManager(e: any) {
      this.selectedTeamMember = e;
      this.newContact.directBossId = this.selectedTeamMember;
      console.log(this.selectedTeamMember);
  
    }

    setSelectedGender(e: any){
      this.selectedGender = e;
      this.newContact.gender = this.selectedGender;
      console.log(this.selectedGender);

    }
    setNameError(){

      this.errorDivName =! this.errorDivName;
    }
    setLNameError(){

      this.errorDivLName =! this.errorDivLName;
    }
    checkPhone()
    {

      this.errorDivPhone = !this.errorDivPhone;
    }

}
