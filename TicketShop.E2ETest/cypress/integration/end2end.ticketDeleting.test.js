
describe('example deleting a ticket', () => {
    beforeEach(() => {
        // open the ticketsController inted page
        cy.visit('https://localhost:44351/Tickets/Delete/51c90298-58d2-4b8b-a9dd-2433155acfb9')
    })
    it('displays creating and editing a ticket', () => {

        // DELETE THE TICKET


        // click on 'Delete'
        cy.get("#delete-btn").click()
       

    })
})