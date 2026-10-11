import { Component, OnInit, ChangeDetectionStrategy, inject, signal } from '@angular/core';
import { DirectBoss } from '../../_models/manager';
import { ContactService } from '../../_sevices/contact.service';
import { Contact } from '../../_models/contact';





@Component({
    selector: 'app-addcontact',
    templateUrl: './addcontact.component.html',
    styleUrls: ['./addcontact.component.css'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class AddcontactComponent implements OnInit {

  private service = inject(ContactService);

  members = signal<DirectBoss[]>([]);
  errorDivName = signal(false);
  errorDivLName = signal(false);
  errorDivPhone = signal(false);
  errorDivManager = signal(true);

  newContact = signal({ phoneNumber: "" } as Contact);


  ngOnInit(): void {

    this.loadTeamMmbers();
  }

  loadTeamMmbers() {


     this.service.getAllTeamMembersList()
      .subscribe(data => {

        this.members.set(data);
        console.log(data);

      }
      );

  }

  updateContact(changes: Partial<Contact>) {

    this.newContact.update(contact => ({ ...contact, ...changes }));
  }

  onSubmit(form: any) {


    this.updateContact({ id: 0 });
    console.log(this.newContact());
    this.service.addNewContact(this.newContact()).subscribe(res => {

    });


   window.location.reload();


  }
    setSelectedManager(e: any) {
      this.errorDivManager.set(false);
      this.updateContact({ directBossId: e });
      console.log(e);

    }

    setSelectedGender(e: any){
      this.updateContact({ gender: e });
      console.log(e);

    }
    setNameError(){

      this.errorDivName.set(true);
    }
    setLNameError(){

      this.errorDivLName.set(true);
    }
    checkPhone()
    {

      this.errorDivPhone.set(true);
    }

}
