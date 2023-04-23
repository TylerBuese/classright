import AnnouncementCard from "../Cards/AnnouncementCard"
import AssignmentCard from "../Cards/AssignmentCard"
import InfoCard from "../Cards/InfoCard"

export default function Index(props) {

    let cookies = document.cookie

    return (
        <>
            
            <div class="flex rounded-md gap-4 columns-3 p-4 ">
                <InfoCard/>
                <AssignmentCard/>
            </div>
            <div class="flex rounded-md gap-4 columns-1 p-4 ">
                {/* <AnnouncementCard/> */}
            </div>
           
        </>
    )
}