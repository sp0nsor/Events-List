import {
  Card,
  CardBody,
  CardHeader,
  Divider,
  Image,
  Text,
} from "@chakra-ui/react";

export default function EventCard({
  name,
  description,
  place,
  time,
  category,
  maxParticipantCount,
  image,
}) {
  return (
    <Card variant={"filled"}>
      <CardHeader size={"md"}>Название: {name}</CardHeader>
      <Divider borderColor={"black"}></Divider>
      <CardBody>
        <Text fontSize="sm">Описание: {description}</Text>
        <Text>Место проведения: {place}</Text>
        <Text>Дата: {time}</Text>
        <Text>Категория: {category}</Text>
        <Text>Количество участников: {maxParticipantCount}</Text>
        {image.fileName && (
          <Image
            src={`data:image/png;base64,${image.fileName}`}
            alt={name}
            borderRadius="lg"
            mb={4}
          />
        )}
      </CardBody>
    </Card>
  );
}
