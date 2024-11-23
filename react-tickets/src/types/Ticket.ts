import { TicketStatus } from "./TicketStatus";

export interface Ticket {
    id: number;
    user: string;
    complaintDescription: string;
    status: TicketStatus;
};