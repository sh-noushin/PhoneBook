import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Contact } from 'src/app/_models/contact';
import { DirectBoss } from 'src/app/_models/manager';
import { ContactService } from 'src/app/_sevices/contact.service';

@Component({
  selector: 'app-editcontact',
  templateUrl: './editcontact.component.html',
  styleUrls: ['./editcontact.component.css']
})
export class EditcontactComponent implements OnInit {


members = [] as Array<DirectBoss>;
contact = {} as Contact;
selectedGender : number =0;
selectedTeamMember : number = 0;
errorDivName: boolean = false;
errorDivLName: boolean = false;
errorDivPhone: boolean = true;


  constructor(private service :ContactService,
    private router: Router) { }

  ngOnInit(): void {

    this.loadTeamMmbers();

    this.loadSelectedContact(this.service.selectedRow);
  }

  loadSelectedContact(id : number)
  {
    this.service.getContactById(id).subscribe(data => {
      this.contact = data;
      console.log(this.contact);
    })
  }

  loadTeamMmbers() {


    this.service.getAllTeamMembersList()
      .subscribe(data => {

        this.members = data;
        console.log(data);

      }
      );

  }

  setSelectedManager(e: any) {
    this.selectedTeamMember = e;
    this.contact.directBossId = this.selectedTeamMember;
    console.log(this.selectedTeamMember);

  }

  setSelectedGender(e: any){
    this.selectedGender = e;
    this.contact.gender = this.selectedGender;
    console.log(this.selectedGender);

  }

  onSubmit(form: any) {

        if(this.contact.name == "")
        {
          this.errorDivLName = true;
        }
        if(this.contact.lName == "")
        {
          this.errorDivPhone = true;
        }
        else{
    console.log(this.contact);
    this.service.editContct(this.contact).subscribe(res => {
      console.log(res);
    });

    this.router.navigateByUrl("/");
  }

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
