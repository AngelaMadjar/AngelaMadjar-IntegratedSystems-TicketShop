
describe('example deleting a ticket', () => {
    beforeEach(() => {
        // open the ticketsController inted page
        cy.visit('https://localhost:44351/Tickets/Delete/59616132-956c-4c6d-bf53-e10fd71af5f4')
    })
    it('displays creating and editing a ticket', () => {

        // DELETE THE TICKET


        // click on 'Delete'
        cy.get("#delete-btn").click()
       

    })
})