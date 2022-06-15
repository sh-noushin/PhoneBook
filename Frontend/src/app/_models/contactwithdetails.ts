export interface ContactWithDetails {
    id: number,
    name: string,
    lName: string,
    gender : string,
    phoneNumber: string,
    team: {
      id: number,
      name: string
    },
    directBoss: {
      id: number,
      fullName: string
    }
}