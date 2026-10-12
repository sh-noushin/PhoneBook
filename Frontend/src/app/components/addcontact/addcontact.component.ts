import { Component, OnInit, ChangeDetectionStrategy, inject, signal } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { DirectBoss } from '../../_models/manager';
import { ContactService } from '../../_sevices/contact.service';
import { Contact } from '../../_models/contact';





@Component({
    selector: 'app-addcontact',
    templateUrl: './addcontact.component.html',
    styleUrls: ['./addcontact.component.scss'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})
export class AddcontactComponent implements OnInit {

  private service = inject(ContactService);
  private router = inject(Router);

  members = signal<DirectBoss[]>([]);
  saving = signal(false);
  saveFailed = signal(false);

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

  onSubmit(form: NgForm) {

    if (form.invalid || this.saving()) {
      return;
    }

    this.updateContact({ id: 0 });
    console.log(this.newContact());
    this.saving.set(true);
    this.saveFailed.set(false);
    this.service.addNewContact(this.newContact()).subscribe({
      next: () => this.router.navigate(['/']),
      error: () => {
        this.saving.set(false);
        this.saveFailed.set(true);
      }
    });

  }
    setSelectedManager(e: any) {
      this.updateContact({ directBossId: e });
      console.log(e);

    }

    setSelectedGender(e: any){
      this.updateContact({ gender: e });
      console.log(e);

    }

}
