
describe('example creating and editing a ticket', () => {
    beforeEach(() => {
        // open the ticketsController inted page
        cy.visit('https://localhost:44351/Tickets')
    })
    it('displays creating and editing a ticket', () => {

        // CREATE A NEW TICKET


        // click on 'Create a new ticket'
        cy.get('#create-new-ticket').click()

        // type the ticket's name
        cy.get('#create-title').type("Bloodshot")

        // type the ticket's image
        cy.get('#create-image').type("https://m.media-amazon.com/images/M/MV5BYjA5YjA2YjUtMGRlNi00ZTU4LThhZmMtNDc0OTg4ZWExZjI3XkEyXkFqcGdeQXVyNjUyNjI3NzU@._V1_.jpg")

        // type the ticket's rating
        cy.get('#create-rating').type(9)

        // type the ticket's price
        cy.get('#create-price').type(150)

        // type the ticket's seat
        cy.get('#create-seat').type(20)

        // type the ticket's date and time
        cy.get('#create-dateandtime').type("2021-06-01T08:30")

        // click the 'Create' button
        cy.get('#create-btn').click()


        // EDIT THE CREATED TICKET

        // click the edit button
        cy.get("#edit-btn").last().click()

        // clear the previous price and type a new one
        cy.get('#edit-price').clear().type(100)

        // save the changes
        cy.get('#edit-savebtn').click()

    })
})