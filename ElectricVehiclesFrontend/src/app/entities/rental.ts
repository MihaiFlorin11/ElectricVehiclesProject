export interface Rental {
    id: number;
    vehicleId: number,
    userId: number,
    invoiceId: number,
    startDateTime: string,
    endDateTime: string
}