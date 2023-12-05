export class Cult{
  constructor(data){
    this.id = data.id
    this.name = data.name
    this.description = data.description
    this.fee = data.fee
    this.coverImg = data.coverImg
    this.memberCount = data.memberCount
    this.invitationRequired = data.invitationRequired
    this.leaderId = data.leaderId
    this.leader = data.leader
  }
}
