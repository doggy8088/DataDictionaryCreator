<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<xsl:stylesheet version="1.0" 
  xmlns="urn:schemas-microsoft-com:office:spreadsheet"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:o="urn:schemas-microsoft-com:office:office"
	xmlns:x="urn:schemas-microsoft-com:office:excel"
	xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
	exclude-result-prefixes="ss">
	<xsl:output method="xml" indent="yes" omit-xml-declaration="no" />
	<xsl:template match="/">
		<xsl:processing-instruction name="mso-application">
			<xsl:text>progid="Excel.Sheet"</xsl:text>
		</xsl:processing-instruction>
		<Workbook>
			<DocumentProperties
		   xmlns="urn:schemas-microsoft-com:office:office">
				<Author>Data Dictionary Creator</Author>
				<LastAuthor>Data Dictionary Creator</LastAuthor>
				<Created></Created>
				<LastSaved></LastSaved>
				<Company></Company>
				<Version></Version>
			</DocumentProperties>
			<ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
				<ActiveSheet>1</ActiveSheet>
				<ProtectStructure>False</ProtectStructure>
				<ProtectWindows>False</ProtectWindows>
			</ExcelWorkbook>
      <Styles>
        <Style ss:ID="Default" ss:Name="Normal">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s21">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s22">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Interior/>
        </Style>
      </Styles>
      <Worksheet ss:Name="Tables">
				<Table x:FullColumns="1" x:FullRows="1" ss:DefaultColumnWidth="150">
          <Column ss:Width="150"/>
          <Column ss:Width="150"/>
          <Column ss:Width="300"/>
          <xsl:apply-templates select="documentation/tables/table" />
				</Table>
			</Worksheet>
      
      <xsl:call-template name="TablesHead" />
		</Workbook>
	</xsl:template>

	<xsl:template match="table">
		<xsl:if test="position()=1">
			<Row>
        <Cell ss:StyleID="s21">
          <Data ss:Type="String">Schema</Data>
        </Cell>
        <Cell ss:StyleID="s21">
          <Data ss:Type="String">Table</Data>
        </Cell>        
        <Cell ss:StyleID="s21">
          <Data ss:Type="String">Description</Data>
        </Cell>
      </Row>
    </xsl:if>
    <Row>
      <Cell ss:StyleID="s22">
        <Data ss:Type="String">
          <xsl:value-of select="@schema" />
        </Data>
      </Cell>
      <Cell ss:StyleID="s22">
				<Data ss:Type="String">
					<xsl:value-of select="@name" />
				</Data>
			</Cell>      
      <Cell ss:StyleID="s22">
				<Data ss:Type="String">
					<xsl:value-of select="@description" />
				</Data>
			</Cell>
		</Row>
	</xsl:template>

  
    
  
  <xsl:template name="TablesHead">
    <xsl:for-each select="documentation/tables/table">
    <Worksheet ss:Name="{@schema}.{@name}">
      <Table x:FullColumns="1" x:FullRows="1" ss:DefaultColumnWidth="150">
        <Column ss:Width="50"/>
        <Column ss:Width="150"/>
        <Column ss:Width="150"/>
        <Column ss:Width="50"/>
        <Column ss:Width="50"/>
        <Column ss:Width="75"/>
        <Column ss:Width="75"/>
        <Column ss:Width="300"/>        
        <xsl:apply-templates select="column" />
      </Table>
    </Worksheet>
    </xsl:for-each>
  </xsl:template>

  <xsl:template match="column">
      <xsl:if test="position()=1">
        <Row>
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">Number</Data>
          </Cell>
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">Column</Data>
          </Cell>
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">Datatype</Data>
          </Cell>
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">Size</Data>
          </Cell>          
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">Nullable</Data>
          </Cell>
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">InPrimaryKey</Data>
          </Cell>
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">IsForeignKey</Data>
          </Cell>          
          <Cell ss:StyleID="s21">
            <Data ss:Type="String">Description</Data>
          </Cell>
          <xsl:for-each select="property">
            <Cell ss:StyleID="s21">
              <Data x:autofilter="all" ss:Type="String">
                <xsl:value-of select="@name"/>
              </Data>
            </Cell>
          </xsl:for-each>
        </Row>
      </xsl:if>
      <Row>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@number"/>
          </Data>
        </Cell>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@name"/>
          </Data>
        </Cell>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@datatype"/>
          </Data>
        </Cell>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@size"/>
          </Data>
        </Cell>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@nullable"/>
          </Data>
        </Cell>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@inprimarykey"/>
          </Data>
        </Cell>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@isforeignkey"/>
          </Data>
        </Cell>
        <Cell ss:StyleID="s22">
          <Data ss:Type="String">
            <xsl:value-of select="@description"/>
          </Data>
        </Cell>
        <xsl:apply-templates select="property" />
      </Row>

  </xsl:template>

  <xsl:template match="property">
    <Cell ss:StyleID="s22">
      <Data ss:Type="String">
				<xsl:value-of select="@value"/>
			</Data>
		</Cell>
	</xsl:template>

</xsl:stylesheet>
